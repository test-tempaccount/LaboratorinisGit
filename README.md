# LaboratorinisGit

## Naudojimas:
.txt failus reikia turėti tame pačiame kataloge su programos .exe failu.  
Programoje galima pasirinkti 1-4 funkcijas.

# Pradinis funkcionalumas (0.1v)

Programa skirta suskaičiuoti studento galutiniui vidurkiui (pagal pažymių medianą arba pagal pažymių vidurkį).

Program.cs: Skaičiavimams naudojamas dinaminis masyvas.
Program2cs: Skaičiavimamsnaudojamas statinis masyvas.
Student.cs: Klasės failas skirtas saugoti studento objektui.

# Nuskaitymas iš failo (0.2v)

Pridėta funkcija skaičiuoti tik studento vidurkį.
Pridėta funkcija skaičiuoti tik studento medianą.
Pridėta funkcija nuskaityti duomenims iš failo.
Pridėta funkcija surasti namų darbų kiekį.

# Išimcių valdymas (0.3v)

Viena klasė buvo išskaidyta į dvi.
Pridėtas pradinis isimciu valdymas, pirminiam ivedimui.
Pridėtas išimčių valdymas failui - aptikimui, nuskaitymui namų darbų pažymių, egzamino rezultato.

# Generavimas ir rūšiavimas (0.4v)

Atliktas pažymių ir pažymių generavimas.
Atliktas sugeneruotų studentų įrašymas į failus.
Atliktas irašytų į failus studentų išrūšiavimas ir išsaugojimas į naujus failus.
Pridėtas paleidimo pasirinkimas, pridėta spartos analizė, kuri atvaizduoja kiek užtruko studentų sąrašų generavimas, įrašymas į failus ir išrūšiavimas.


# Rūšiavimas ir spartos matavimas (0.5v)

Matuojama rūšiavimo spartą naudojant List, LinkedList ir Queue.  

Failų rūšiavimas su List užtruko 2,623 sekundes.  
Failų rūšiavimas su LinkedList užtruko 5,947 sekundes.  
Failų rūšsiavimas su Queue užtruko 5,259 sekundes.  

Testas atliktas su 10 milijonų dydžio sąrašu.

# Galutinė versija (1.0v)
## Naudojamas 10 milijonų elementų dydžio failas.
  
Atliekama 1 strategija.  
Failų rūšiavimas su List užtruko 3,047 sekundes.  
Failų rūšiavimas su LinkedList užtruko 11,991 sekundes.  
Failų rūšiavimas su Queue užtruko 5,466 sekundes.  

Atliekama 2 strategija (su rusiavimu).  
Failų rūšiavimas su List užtruko 25,562 sekundes.  
Failų rūšiavimas su LinkedList užtruko 26,493 sekundes.  
Failų rūšiavimas su Queue užtruko 33,393 sekundes.  

Atliekamas optimizuoto ir neoptimizuoto (išrūšiuoto) List<T> testavimas.  
Failų rūšiavimas su List, naudojant AddRange užtruko 24,851 sekundes.  
Failų rūšiavimas su List, naudojant Insert užtruko 25,537 sekundes.    

Rūšiavimas užtrunka daug laiko, tačiau labai naudinga jeigu iš List<T>, LinkedList<T> ar Queue<T> bus šalinimi, elementai, nes nereikia su kiekvienu List<T>.RemoveAt() ar List<T>.Remove() perstumpti viso dinaminio masyvo. Čia būtu galima optimizuoti kodą, naudojant statinį masyvą.  

