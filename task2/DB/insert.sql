INSERT INTO persons (first_name,last_name,birth_date,gender,salary,mother_id,father_id)
VALUES
-- Pokolenie 1 (dziadkowie)
('Jan'  ,'Kowalski'  , '1945-06-10', 'M',  9000, NULL, NULL),     -- 1
('Maria','Kowalska'  , '1948-11-22', 'F',  7500, NULL, NULL),     -- 2
-- Pokolenie 2
('Piotr','Kowalski'  , '1970-01-03', 'M', 12000, 2, 1),           -- 3
('Anna' ,'Kowalska'  , '1972-07-14', 'F', 11500, 2, 1),           -- 4
-- Małżonkowie pokolenia 2
('Ewa'  ,'Nowak'     , '1971-02-19', 'F',  8900, NULL, NULL),     -- 5
('Marek','Wiśniewski', '1969-12-30', 'M',  9800, NULL, NULL),     -- 6
-- Pokolenie 3 (wnuki)
('Ola'  ,'Kowalska'  , '1995-05-05', 'F',  7000, 5, 3),           -- 7
('Paweł','Kowalski'  , '1998-09-08', 'M',  7200, 5, 3),           -- 8
('Zosia','Wiśniewska', '2000-03-12', 'F',  6800, 4, 6),           -- 9
('Kasia','Wiśniewska', '2003-10-21', 'F',  6400, 4, 6);           -- 10
GO

-- ----  MAŁŻEŃSTWA  ----
INSERT INTO marriages (husband_id,wife_id) VALUES
(3,5),   -- Piotr - Ewa
(6,4);   -- Marek - Anna
GO

-- ----  FIRMY  ----
INSERT INTO enterprises (name,president_id) VALUES
('Tech‑Corp'     , 3),  -- Piotr
('Biz‑Sp z.o.o.' , 6);  -- Marek
GO

-- ----  ZATRUDNIENIA  ----
INSERT INTO employments (person_id,enterprise_id,contract_type) VALUES
(3,1,'umowa_o_prace'),
(5,1,'umowa_zlecenie'),
(7,1,'umowa_zlecenie'),
(8,1,'umowa_o_prace'),
(4,2,'umowa_o_prace'),
(6,2,'umowa_o_prace'),
(9,2,'umowa_zlecenie');
GO