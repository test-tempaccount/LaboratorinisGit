# LaboratorinisGit

Atliekama 1 strategija
Failu rusiavimas su List uztruko 0,302 sekundes
Failu rusiavimas su LinkedList uztruko 0,699 sekundes
Failu rusiavimas su Queue uztruko 0,368 sekundes
-------------------------------------
Atliekama 2 strategija (su rusiavimu)
Failu rusiavimas su List uztruko 1,652 sekundes
Failu rusiavimas su LinkedList uztruko 1,635 sekundes
Failu rusiavimas su Queue uztruko 1,736 sekundes
-------------------------------------
Atliekamas optimizuoto ir neoptimizuoto List<T> testavimas
Failu rusiavimas su List, naudojant AddRange uztruko 1,682 sekundes
Failu rusiavimas su List, naudojant Insert uztruko 1,558 sekundes
-------------------------------------
  
Rūšiavimas užtrunka daug laiko, tačiau labai naudinga jeigu iš List<T> bus šalinimi, elementai, nes nereikia su kiekvienu List<T>.RemoveAt() ar List<T>.Remove() perstumpti viso dinaminio masyvo.

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
