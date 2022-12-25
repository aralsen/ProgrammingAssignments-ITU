import sys

RED = True
BLACK = False


class RBNode:
    def __init__(self, name, color, data, parent):
        self.name = name  # Player Name-Surname
        self.color = color  # color of node -> True if it is RED, False if it is BLACK
        self.data = data  # players total number of rebounds, assists, points
        self.parent = parent  # Parent of player node
        self.left = None  # Left-Child of player node
        self.right = None  # Right-Child of player node
        self.max_stats = [n for n in data]  # because it was bottom node at first, the maximum stats equaled the data
        self.own_max = [name for _ in range(3)]  # owners of all max stats

    def uncle(self):
        gp = self.parent.parent  # grandparent
        if gp.left == self.parent:
            return gp.right
        else:
            return gp.left

    def pre_order(self, padding=""):
        if self:
            print(padding + str(self))
            RBNode.pre_order(self.left, padding + "-")
            RBNode.pre_order(self.right, padding + "-")

    def __str__(self):
        if self.color:
            return "(RED) " + self.name
        else:
            return "(BLACK) " + self.name


def rotate_left(node):
    cur_right = node.right  # set the right-child

    if node.parent:  # if node has a parent swap
        swap_node(node, cur_right)

    if cur_right.left is not None:
        cur_right.left.parent = node

    node.right, cur_right.left = cur_right.left, node  # swap children
    cur_right.parent, node.parent = node.parent, cur_right  # swap parents

    update_stats(node, cur_right)
    update_node_rotate(node, cur_right)


def rotate_right(node):
    cur_left = node.left  # set the left-child

    if node.parent:  # if node has a parent swap it
        swap_node(node, cur_left)

    if cur_left.right is not None:
        cur_left.right.parent = node

    node.left, cur_left.right = cur_left.right, node  # swap children
    cur_left.parent, node.parent = node.parent, cur_left  # swap parents

    update_stats(node, cur_left)
    update_node_rotate(node, cur_left)


def balance(node):
    while node.parent and node.parent.color is RED:
        uncle = node.uncle()
        # Insertion strategy
        # case1: -> node.UNCLE = red
        # Solution: Recolor
        if uncle and (uncle.color is RED):
            node.parent.parent.color = RED
            node.parent.color = BLACK
            uncle.color = BLACK
            node = node.parent.parent
        else:
            parent = node.parent
            grandparent = node.parent.parent

            # LR
            if node == parent.right and parent == grandparent.left:
                rotate_left(parent)
                rotate_right(grandparent)
                node.color = BLACK
                grandparent.color = RED
                node = parent

            # LL
            elif node == parent.left and parent == grandparent.left:
                rotate_right(grandparent)
                parent.color = BLACK
                grandparent.color = RED

            # RR
            elif node == parent.right and parent == grandparent.right:
                rotate_left(grandparent)
                parent.color = BLACK
                grandparent.color = RED

            # RL
            elif node == parent.left and parent == grandparent.right:
                rotate_right(parent)
                rotate_left(grandparent)
                node.color = BLACK
                grandparent.color = RED
                node = parent

    if not node.parent:
        node.color = BLACK


def update(node):
    if not node or not node.parent:
        return False

    updated = False
    for i in range(3): # range in all stat types
        if node.max_stats[i] > node.parent.max_stats[i]:  # update every stat type
            node.parent.max_stats[i] = node.max_stats[i]
            node.parent.own_max[i] = node.own_max[i]
            updated = True

    return updated


def update_until_root(node):
    updated = update(node)
    if updated:
        update_until_root(node.parent)


def update_node_rotate(node, child):
    update(node.left)
    update(node.right)
    update(child.left)
    update(child.right)


def update_stats(node, child):
    node.max_stats = [stat for stat in node.data]  # updating max stats
    child.max_stats = [stat for stat in node.data]


def swap_node(node, child):
    if node.parent.left == node:
        node.parent.left = child
    else:
        node.parent.right = child


def insert_data(root, player_data):
    parent_last = direction = None

    while root is not None:
        if root.name == player_data[1]:  # player is the current node
            root.data = [root.data[i] + player_data[i + 3] for i in range(3)]  # update old stats

            for i in range(3):  # update max_stats
                if root.max_stats[i] < root.data[i]:
                    root.max_stats[i] = root.data[i]
                    root.own_max[i] = root.name

            update_until_root(root)
            return

        elif root.name > player_data[1]:  # name > root name
            parent_last = root
            root = root.left
            direction = True

        else:  # name < root name
            parent_last = root
            root = root.right
            direction = False

    new = RBNode(player_data[1], RED, player_data[3:], parent_last)
    if direction:
        parent_last.left = new
    else:
        parent_last.right = new

    update_until_root(new)
    balance(new)


def season_insert(root, players, current):
    current_season = players[current][0]

    while current < len(players) and players[current][0] == current_season:  # while in this season
        insert_data(root, players[current])
        current += 1
        while root.parent:
            root = root.parent  # If the root has been relocated, return it back to the top.

    return root, current


def init_data(file_name):
    with open(file_name, "r") as f:
        lines = f.readlines()[1:]
        data = [player.strip().split(",") for player in lines]
        data = [player[:3] + list(map(int, player[3:])) for player in data]

    return data


def print_season(score_types, players, root, current):
    print("End of the " + players[current - 1][0] + " Season")
    for i in range(2, -1, -1):
        print("Max " + score_types[i] + ": " + str(root.max_stats[i]) + " - Player Name: " + root.own_max[i])


def main():
    stats = ["Rebs", "Assists", "Points"]
    csv_file = sys.argv[1]
    players = init_data(csv_file)

    root = RBNode(players[0][1], BLACK, players[0][3:], None)

    root, current = season_insert(root, players, 0)  # first season
    print_season(stats, players, root, current)
    root.pre_order()  # print first-season in tree form

    while current < len(players):  # print other seasons
        root, current = season_insert(root, players, current)
        print_season(stats, players, root, current)


if __name__ == "__main__":
    main()
