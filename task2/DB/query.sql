-- A. Znajdź imię i nazwisko osoby posiadającej największą liczbę wnucząt płci żeńskiej.
PRINT 'A. Osoba z największą liczbą wnucząt płci żeńskiej';
WITH wnuczki AS (
    SELECT gp.id AS grandparent_id
    FROM persons AS gp												 -- grandparent
    JOIN persons AS c ON c.mother_id = gp.id OR c.father_id = gp.id  -- children
    JOIN persons AS gc ON gc.mother_id = c.id OR gc.father_id = c.id -- grandchildren
    WHERE gc.gender = 'F'
)
SELECT TOP(1) WITH TIES 
       p.first_name,
       p.last_name,
       COUNT(*)  AS liczba_wnuczek
FROM persons     AS p
JOIN wnuczki     AS w ON w.grandparent_id = p.id
GROUP BY p.id, p.first_name, p.last_name
ORDER BY COUNT(*) DESC;
GO

-- B. Przedstaw średnią ilość pracowników zatrudnionych na umowę zlecenie i średnią ilość pracowników zatrudnionych 
-- na umowę o pracę we wszystkich firmach oraz średnią pensję dla tych umów.
PRINT 'B. Średnie liczby pracowników i średnie pensje według typu umowy (we wszystkich firmach)';
WITH company_stats AS (
    SELECT e.enterprise_id,
           SUM(CASE WHEN e.contract_type='umowa_zlecenie' THEN 1 END)		 AS cnt_zlec,
           SUM(CASE WHEN e.contract_type='umowa_o_prace'  THEN 1 END)		 AS cnt_opr,
           AVG(CASE WHEN e.contract_type='umowa_zlecenie' THEN p.salary END) AS avg_sal_zlec,
           AVG(CASE WHEN e.contract_type='umowa_o_prace'  THEN p.salary END) AS avg_sal_opr
    FROM employments     AS e
    JOIN persons         AS p ON p.id = e.person_id
    GROUP BY e.enterprise_id
)
SELECT AVG(cnt_zlec)	 AS sr_liczba_zlec,
       AVG(cnt_opr)		 AS sr_liczba_opr,
       AVG(avg_sal_zlec) AS sr_pensja_zlec,
       AVG(avg_sal_opr)  AS sr_pensja_opr
FROM company_stats;
GO

-- Znajdź rodzinę (co najwyżej 2 pokoleniową) najmniej zarabiającą. Przedstaw imię i nazwisko dowolnej osoby z tej rodziny.
-- Podpowiedź: rodzina 1-pokoleniowa to osoba X z ewentualnym współmałżonkiem. Rodzina 2-pokoleniowa to rodzina 1-pokoleniowa 
-- z wszystkimi jej dziećmi (wraz z ewentualnymi współmałżonkami) lub rodzicami.
PRINT 'C. Najbiedniejsza rodzina (≤ 2 pokolenia) – dowolna osoba';
WITH family(root_id, member_id) AS (
    SELECT p.id, p.id
    FROM persons   AS p
    UNION
    SELECT p.id, CASE WHEN m.husband_id = p.id THEN m.wife_id ELSE m.husband_id END
    FROM persons   AS p
    JOIN marriages AS m ON m.husband_id = p.id OR m.wife_id = p.id

    UNION ALL
    SELECT f.root_id, c.id        -- dzieci
    FROM family    AS f
    JOIN persons   AS c ON c.mother_id = f.member_id OR c.father_id = f.member_id

    UNION ALL
    SELECT f.root_id, sp.id       -- małżonkowie dzieci
    FROM family	   AS f
    JOIN persons   AS c ON c.mother_id = f.member_id OR c.father_id = f.member_id
    JOIN marriages AS m ON m.husband_id = c.id OR m.wife_id = c.id
    JOIN persons   AS sp ON sp.id = m.husband_id OR sp.id = m.wife_id
)
, family_income AS (
    SELECT root_id, SUM(p.salary) AS total_income
    FROM family
    JOIN persons   AS p ON p.id = family.member_id
    GROUP BY root_id
)
SELECT TOP(1)
       per.first_name,
       per.last_name,
       fi.total_income
FROM family_income AS fi
JOIN persons       AS per ON per.id = fi.root_id
ORDER BY fi.total_income;   -- najniższy dochód
GO
