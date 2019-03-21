using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisGit
{

    class Program
    {

        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();

            bool testi = true;
            bool testi2 = true;

            Random rnd = new Random();
            int month = rnd.Next(1, 11);

            while (testi) {

            testi2 = true;

            Console.WriteLine("Iveskite varda");
            String vardas = Console.ReadLine();

            Console.WriteLine("Iveskite pavarde");
            String pavarde = Console.ReadLine();

            Student studentas = new Student(vardas, pavarde);

            while (testi2) {

            Console.WriteLine("Iveskite nd pazymius (b - baigti)");
            String input = Console.ReadLine();

            if (input.Equals("b")) {
                testi2 = false;
                break;
                }else{
                    studentas.addPazimys(double.Parse(input));
                }
            }

            Console.WriteLine("Iveskite egzamino rezultata");
            double egzaminas = double.Parse(Console.ReadLine());
            studentas.addEgzaminas(egzaminas);
            studentas.setVidurkis(skaiciuotiVidurki(studentas));
            students.Add(studentas);

           

            Console.WriteLine("Ar norite dar prideti studenta? (t/n)");
            String tesimas = Console.ReadLine();

            if (tesimas.Equals("n")){
                    testi=false;
            }

            }


            Console.WriteLine("{0,0}{1,15}{2,20}", "Vardas", "Pavarde", "Galutinis (Vid.)");
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("{0,0}{1,15}{2,20}", students.ElementAt(i).getVardas(), students.ElementAt(i).getPavarde(), students.ElementAt(i).getVidurkis());
            }

        }

        static double skaiciuotiVidurki(Student student)
        {
            double suma = 0;
            List<double> ls = student.getPazymiai();
            for (int i = 0; i < ls.Count; i++) {
                suma += ls.ElementAt(i);
            }


            return 0.3*(suma/ls.Count) + 0.7 * student.getEgzaminas();

        }



        public static decimal skaiciuotiMediana(int[] array) {

            int[] tempArray = array;
            int count = tempArray.Length;

            Array.Sort(tempArray);

            decimal mediana = 0;

            if (count % 2 == 0){

                int kaire = tempArray[(count / 2) - 1];
                int desine = tempArray[(count / 2)];
                mediana = (kaire + desine) / 2;

            }else{
                mediana = tempArray[(count / 2)];
            }

            return mediana;
        }

        class Student {

            String name = "";
            String surname = "";
            double egzaminas;
            double vidurkis;
            List<double> pazymiai = new List<double>();

            public Student(String name, String surname) {
                this.name = name;
                this.surname = surname;
            }


            public void addPazimys(double pazimys) {
                pazymiai.Add(pazimys);
            }

            public void addEgzaminas(double pazimys)
            {
                egzaminas = pazimys;
            }

            public double getEgzaminas()
            {
                return egzaminas;
            }


            public List<double> getPazymiai() {
                return pazymiai;
            }

            public String getVardas()
            {
                return name;
            }

            public String getPavarde()
            {
                return surname;
            }

            public double getVidurkis()
            {
                return vidurkis;
            }

            public void setVidurkis(double vidurkis)
            {
                this.vidurkis = vidurkis;
            }



        }

    }
}