using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisGit
{
    class Student
    {

        String name = "";
        String surname = "";
        double egzaminas;
        double vidurkis;
        int mediana;
        List<int> pazymiai = new List<int>();

        public Student(String name, String surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public void setPazymiai(List<int> pazymiai)
        {
            this.pazymiai = pazymiai;
        }

        public void addPazimys(int pazimys)
        {
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


        public List<int> getPazymiai()
        {
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

        public double getMediana()
        {
            return mediana;
        }

        public void setMediana(int vidurkis)
        {
            this.mediana = mediana;
        }



    }
}
