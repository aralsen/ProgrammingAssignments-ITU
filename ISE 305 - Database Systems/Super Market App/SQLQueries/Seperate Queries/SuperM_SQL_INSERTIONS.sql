insert into job_types (description) values ('Manager'), ('Salesperson')
--Managers
insert into employees (employee_id, email, name, phone, age, job_id, password) values (1, 'sena17@itu.edu.tr', 'Aral Sen', '226-555-6228', 24, 1, 'aral22');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (2, 'lcathro1@oracle.com', 'Lemmie Cathro', '198-343-6068', 30, 1, 'PkoA8Jkp');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (3, 'mcrufts2@last.fm', 'Marleah Crufts', '688-404-1963', 27, 1, 'h7m4RznPoPg');

--Salespersons
insert into employees (employee_id, email, name, phone, age, job_id, password) values (4, 'bdevenport0@joomla.org', 'Brandea Devenport', '599-916-0659', 23, 2, 'WboPF0RSCFHr');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (5, 'spowis1@time.com', 'Sax Powis', '614-710-8591', 57, 2, 'JGuPV7XqEdG5');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (6, 'jbenesevich2@ucsd.edu', 'Janel Benesevich', '771-697-8110', 31, 2, 'cDgVoX7Eg');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (7, 'vcampana3@mit.edu', 'Vassili Campana', '618-240-4455', 34, 2, 'hK1wxBKEoV');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (8, 'wovanesian4@europa.eu', 'Walther Ovanesian', '198-209-3315', 21, 2, 'oVtxuFNYm');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (9, 'lquixley5@globo.com', 'Lorry Quixley', '656-530-8986', 44, 2, 'FP1WW9wYyE');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (10, 'akrolman6@amazon.de', 'Amelia Krolman', '355-110-2956', 59, 2, 'RVXN4sCOattY');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (11, 'cbladen7@google.co.jp', 'Corette Bladen', '824-313-5512', 58, 2, 'GUOWWl');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (12, 'nharragin8@ed.gov', 'Nola Harragin', '570-686-4310', 51, 2, 'hKiZf9O8vS');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (13, 'moolahan9@vkontakte.ru', 'Mead Oolahan', '319-358-5782', 30, 2, '1q1jLgx0Z');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (14, 'cgheeraerta@ox.ac.uk', 'Cybill Gheeraert', '410-280-9376', 19, 2, 'fgBnXk');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (15, 'bsegoeb@skyrock.com', 'Brunhilda Segoe', '831-221-2795', 31, 2, 'EMs0SDX');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (16, 'sburnettc@cnn.com', 'Shannon Burnett', '596-534-9020', 49, 2, 'lDh5O89N099');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (17, 'gdovydenasd@nationalgeographic.com', 'Gena Dovydenas', '963-208-2298', 60, 2, 'O3Bq6dfKUK1u');
insert into employees (employee_id, email, name, phone, age, job_id, password) values (18, 'bwardlawe@fc2.com', 'Bax Wardlaw', '388-263-0134', 41, 2, 'avZ5ci55');

--Categories

insert into categories (category_id, category_name, description) values (1, 'Grocery', 'Items of food sold');
insert into categories (category_id, category_name, description) values (2, 'Furniture', 'The movable articles that are used to make a room or building suitable for living or working');
insert into categories (category_id, category_name, description) values (3, 'Office Supplies', 'Office supplies are consumables and equipment regularly used in offices by businesses and other organizations');
insert into categories (category_id, category_name, description) values (4, 'Technology', 'From true wireless earbuds to smart home appliances to tech products for parents, here are the coolest gadgets available right now.');

--Grocery
insert into products (product_id, product_name, stock, price, category_id) values (1, 'Lamb - Pieces, Diced', 76, 18, 1);
insert into products (product_id, product_name, stock, price, category_id) values (2, 'Cookie - Oreo 100x2', 92, 30, 1);
insert into products (product_id, product_name, stock, price, category_id) values (3, 'Wasabi Paste', 13, 29, 1);
insert into products (product_id, product_name, stock, price, category_id) values (4, 'Limes', 63, 76, 1);
insert into products (product_id, product_name, stock, price, category_id) values (5, 'Pork - Caul Fat', 81, 35, 1);
insert into products (product_id, product_name, stock, price, category_id) values (6, 'Icecream - Dstk Cml And Fdg', 46, 43, 1);
insert into products (product_id, product_name, stock, price, category_id) values (7, 'Mushroom - Lg - Cello', 78, 73, 1);
insert into products (product_id, product_name, stock, price, category_id) values (8, 'Bread - Pullman, Sliced', 85, 11, 1);
insert into products (product_id, product_name, stock, price, category_id) values (9, 'Juice - Happy Planet', 37, 45, 1);
insert into products (product_id, product_name, stock, price, category_id) values (10, 'Lamb - Racks, Frenched', 6, 66, 1);
insert into products (product_id, product_name, stock, price, category_id) values (11, 'Pasta - Gnocchi, Potato', 33, 17, 1);
insert into products (product_id, product_name, stock, price, category_id) values (12, 'Chocolate Bar - Smarties', 35, 30, 1);
insert into products (product_id, product_name, stock, price, category_id) values (13, 'Ice Cream - Strawberry', 1, 23, 1);
insert into products (product_id, product_name, stock, price, category_id) values (14, 'Mace', 22, 53, 1);
insert into products (product_id, product_name, stock, price, category_id) values (15, 'Wine - Chablis 2003 Champs', 61, 31, 1);
insert into products (product_id, product_name, stock, price, category_id) values (16, 'Rum - Cream, Amarula', 39, 25, 1);
insert into products (product_id, product_name, stock, price, category_id) values (17, 'Pastry - Chocolate Chip Muffin', 77, 29, 1);
insert into products (product_id, product_name, stock, price, category_id) values (18, 'Ecolab - Hobart Washarm End Cap', 28, 14, 1);
insert into products (product_id, product_name, stock, price, category_id) values (19, 'Syrup - Monin, Swiss Choclate', 24, 34, 1);
insert into products (product_id, product_name, stock, price, category_id) values (20, 'Pepper - White, Whole', 62, 49, 1);
insert into products (product_id, product_name, stock, price, category_id) values (21, 'Coffee Caramel Biscotti', 8, 39, 1);
insert into products (product_id, product_name, stock, price, category_id) values (22, 'Bread Foccacia Whole', 22, 22, 1);
insert into products (product_id, product_name, stock, price, category_id) values (23, 'Chilli Paste, Sambal Oelek', 86, 21, 1);
insert into products (product_id, product_name, stock, price, category_id) values (24, 'Juice - Happy Planet', 89, 38, 1);
insert into products (product_id, product_name, stock, price, category_id) values (25, 'Chocolate Bar - Smarties', 54, 58, 1);
insert into products (product_id, product_name, stock, price, category_id) values (26, 'Beer - Camerons Cream Ale', 51, 69, 1);
insert into products (product_id, product_name, stock, price, category_id) values (27, 'Chicken - Wings, Tip Off', 76, 49, 1);
insert into products (product_id, product_name, stock, price, category_id) values (28, 'Eggroll', 46, 16, 1);
insert into products (product_id, product_name, stock, price, category_id) values (29, 'Bread - French Baquette', 45, 65, 1);
insert into products (product_id, product_name, stock, price, category_id) values (30, 'Muskox - French Rack', 75, 74, 1);
insert into products (product_id, product_name, stock, price, category_id) values (31, 'Pepper - Pablano', 1, 39, 1);
insert into products (product_id, product_name, stock, price, category_id) values (32, 'Pork - Sausage Casing', 22, 74, 1);
insert into products (product_id, product_name, stock, price, category_id) values (33, 'Bread - White, Sliced', 37, 19, 1);
insert into products (product_id, product_name, stock, price, category_id) values (34, 'Cream - 10%', 28, 75, 1);
insert into products (product_id, product_name, stock, price, category_id) values (35, 'Ice Cream - Strawberry', 2, 41, 1);
insert into products (product_id, product_name, stock, price, category_id) values (36, 'Avocado', 69, 59, 1);
insert into products (product_id, product_name, stock, price, category_id) values (37, 'Ham - Cooked Bayonne Tinned', 3, 28, 1);
insert into products (product_id, product_name, stock, price, category_id) values (38, 'Ostrich - Fan Fillet', 21, 17, 1);
insert into products (product_id, product_name, stock, price, category_id) values (39, 'Brandy Apricot', 46, 14, 1);
insert into products (product_id, product_name, stock, price, category_id) values (40, 'Cherries - Maraschino,jar', 44, 73, 1);
insert into products (product_id, product_name, stock, price, category_id) values (41, 'Foam Dinner Plate', 40, 38, 1);
insert into products (product_id, product_name, stock, price, category_id) values (42, 'Milk - Homo', 7, 53, 1);
insert into products (product_id, product_name, stock, price, category_id) values (43, 'Pepper - Green', 94, 26, 1);
insert into products (product_id, product_name, stock, price, category_id) values (44, 'Potatoes - Mini White 3 Oz', 61, 16, 1);
insert into products (product_id, product_name, stock, price, category_id) values (45, 'Pasta - Cannelloni, Sheets, Fresh', 87, 57, 1);
insert into products (product_id, product_name, stock, price, category_id) values (46, 'Apple - Delicious, Golden', 36, 45, 1);
insert into products (product_id, product_name, stock, price, category_id) values (47, 'Wine - Shiraz South Eastern', 27, 39, 1);
insert into products (product_id, product_name, stock, price, category_id) values (48, 'Chocolate - Pistoles, Lactee, Milk', 73, 54, 1);
insert into products (product_id, product_name, stock, price, category_id) values (49, 'Table Cloth 54x72 Colour', 97, 73, 1);
insert into products (product_id, product_name, stock, price, category_id) values (50, 'Mushroom - Lg - Cello', 29, 22, 1);


--Furniture
insert into products (product_id, product_name, stock, price, category_id) values (51, 'Chicken - Thigh, Bone In', 16, 163, 2);
insert into products (product_id, product_name, stock, price, category_id) values (52, 'Parsley - Dried', 18, 291, 2);
insert into products (product_id, product_name, stock, price, category_id) values (53, 'Lamb - Shoulder', 25, 410, 2);
insert into products (product_id, product_name, stock, price, category_id) values (54, 'Spinach - Spinach Leaf', 15, 377, 2);
insert into products (product_id, product_name, stock, price, category_id) values (55, 'Pickle - Dill', 14, 644, 2);
insert into products (product_id, product_name, stock, price, category_id) values (56, 'Extract - Almond', 21, 316, 2);
insert into products (product_id, product_name, stock, price, category_id) values (57, 'Nacho Chips', 36, 375, 2);
insert into products (product_id, product_name, stock, price, category_id) values (58, 'Soup Campbells Beef With Veg', 25, 271, 2);
insert into products (product_id, product_name, stock, price, category_id) values (59, 'Kippers - Smoked', 3, 222, 2);
insert into products (product_id, product_name, stock, price, category_id) values (60, 'Basil - Thai', 15, 604, 2);
insert into products (product_id, product_name, stock, price, category_id) values (61, 'Pastry - Chocolate Chip Muffin', 22, 213, 2);
insert into products (product_id, product_name, stock, price, category_id) values (62, 'Bread - Dark Rye', 15, 574, 2);
insert into products (product_id, product_name, stock, price, category_id) values (63, 'Wine - Chenin Blanc K.w.v.', 6, 208, 2);
insert into products (product_id, product_name, stock, price, category_id) values (64, 'Sauce - Marinara', 44, 412, 2);
insert into products (product_id, product_name, stock, price, category_id) values (65, 'Limes', 15, 363, 2);

--Office Supplies
insert into products (product_id, product_name, stock, price, category_id) values (66, 'Lettuce - Iceberg', 11, 553, 3);
insert into products (product_id, product_name, stock, price, category_id) values (67, 'Almonds Ground Blanched', 16, 423, 3);
insert into products (product_id, product_name, stock, price, category_id) values (68, 'Salt - Sea', 15, 446, 3);
insert into products (product_id, product_name, stock, price, category_id) values (69, 'Wine - Cotes Du Rhone', 26, 630, 3);
insert into products (product_id, product_name, stock, price, category_id) values (70, 'Buttons', 3, 508, 3);
insert into products (product_id, product_name, stock, price, category_id) values (71, 'Dried Cherries', 17, 185, 3);
insert into products (product_id, product_name, stock, price, category_id) values (72, 'Wonton Wrappers', 23, 376, 3);
insert into products (product_id, product_name, stock, price, category_id) values (73, 'Chicken - White Meat With Tender', 13, 574, 3);
insert into products (product_id, product_name, stock, price, category_id) values (74, 'Pastry - French Mini Assorted', 15, 629, 3);
insert into products (product_id, product_name, stock, price, category_id) values (75, 'Bread Base - Italian', 4, 185, 3);
insert into products (product_id, product_name, stock, price, category_id) values (76, 'Ecolab - Hand Soap Form Antibac', 1, 601, 3);
insert into products (product_id, product_name, stock, price, category_id) values (77, 'Rice - Sushi', 44, 440, 3);
insert into products (product_id, product_name, stock, price, category_id) values (78, 'Cake Sheet Combo Party Pack', 34, 408, 3);
insert into products (product_id, product_name, stock, price, category_id) values (79, 'Honey - Liquid', 14, 524, 3);
insert into products (product_id, product_name, stock, price, category_id) values (80, 'Fish - Scallops, Cold Smoked', 21, 441, 3);

--Technology
insert into products (product_id, product_name, stock, price, category_id) values (81, 'Liners - Baking Cups', 27, 439, 4);
insert into products (product_id, product_name, stock, price, category_id) values (82, 'Beans - Yellow', 16, 612, 4);
insert into products (product_id, product_name, stock, price, category_id) values (83, 'Sword Pick Asst', 44, 249, 4);
insert into products (product_id, product_name, stock, price, category_id) values (84, 'Tea - Mint', 7, 244, 4);
insert into products (product_id, product_name, stock, price, category_id) values (85, 'Gatorade - Cool Blue Raspberry', 18, 393, 4);
insert into products (product_id, product_name, stock, price, category_id) values (86, 'Yoplait - Strawbrasp Peac', 7, 708, 4);
insert into products (product_id, product_name, stock, price, category_id) values (87, 'Venison - Racks Frenched', 22, 253, 4);
insert into products (product_id, product_name, stock, price, category_id) values (88, 'Shopper Bag - S - 4', 13, 621, 4);
insert into products (product_id, product_name, stock, price, category_id) values (89, 'Pork - Ham Hocks - Smoked', 31, 488, 4);
insert into products (product_id, product_name, stock, price, category_id) values (90, 'Hinge W Undercut', 9, 372, 4);
insert into products (product_id, product_name, stock, price, category_id) values (91, 'Fudge - Cream Fudge', 24, 372, 4);
insert into products (product_id, product_name, stock, price, category_id) values (92, 'Rum - White, Gg White', 13, 434, 4);
insert into products (product_id, product_name, stock, price, category_id) values (93, 'Devonshire Cream', 29, 597, 4);
insert into products (product_id, product_name, stock, price, category_id) values (94, 'Oregano - Dry, Rubbed', 50, 618, 4);
insert into products (product_id, product_name, stock, price, category_id) values (95, 'Potatoes - Peeled', 4, 434, 4);

