import csv

# Path to the CSV file
csv_file_path = 'peikko_data.csv'

# Path to the output SQL file
sql_file_path = 'insert_peikko_data.sql'

# Write the SQL file
with open(csv_file_path, mode='r', encoding='utf-8') as csvfile, open(sql_file_path, mode='w', encoding='utf-8') as sqlfile:
    reader = csv.reader(csvfile)
    header = next(reader)  
    
    # Write table creation statement
    sqlfile.write("""
IF OBJECT_ID('peikko_table', 'U') IS NULL
BEGIN
    CREATE TABLE peikko_table (
        NIMI NVARCHAR(50),
        sisap_mat NVARCHAR(50),
        ulkop_mat NVARCHAR(50),
        vinosit_mat NVARCHAR(50),
        H INT,
        Lmin INT,
        Lmax INT,
        moduli INT,
        eriste INT,
        eriste_min INT,
        eriste_max INT,
        sisap_d INT,
        ulkop_d INT,
        vinop_d INT,
        Fk_kN FLOAT
    );
END;
\n""")
    
    # Write data insertion statements
    for row in reader:
        processed_row = [
            f"'{row[0]}'",  # NIMI
            f"'{row[1]}'",  # sisap_mat
            f"'{row[2]}'",  # ulkop_mat
            f"'{row[3].replace(',', '.')}'",  # vinosit_mat
            int(row[4]),  # H
            int(row[5]),  # Lmin
            int(row[6]),  # Lmax
            int(row[7]),  # moduli
            int(row[8]),  # eriste
            int(row[9]),  # eriste_min
            int(row[10]), # eriste_max
            int(row[11]), # sisap_d
            int(row[12]), # ulkop_d
            int(row[13]), # vinop_d
            float(row[14].replace(',', '.'))  # Fk_kN
        ]
        
        # Create INSERT INTO statement
        insert_query = f"""
INSERT INTO peikko_table (
    NIMI, sisap_mat, ulkop_mat, vinosit_mat, H, Lmin, Lmax, moduli,
    eriste, eriste_min, eriste_max, sisap_d, ulkop_d, vinop_d, Fk_kN
) VALUES ({', '.join(map(str, processed_row))});
"""
        
        sqlfile.write(insert_query)

print(f"SQL file '{sql_file_path}' generated successfully!")
