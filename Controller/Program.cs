using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Entity;
using Model.Logic;
using static View.Print;
using static Util.Util;

namespace Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task \"School pupils\"\n");

            IPupilDAO pupilDao = new SqlPupilDAO();
            Console.WriteLine("Count pupils in database: " + pupilDao.GetCountPupil() + "\n");
            
            //вывод на консоль все учеников
            IList<Pupil> list = pupilDao.GetAllPupils();
            Console.WriteLine("Pupils information:\n" + Show(list));

            //вывод на консоль одного ученика
            Console.WriteLine("Print information pupil by id");
            Console.Write("Enter id pupil: ");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine(pupilDao.GetPupil(id));
            Console.WriteLine();
            
            //добавление ученика в базу данных
            Console.WriteLine("Add pupil in database");
            pupilDao.InsertPupil(GetPupil());
            list = pupilDao.GetAllPupils();
            Console.WriteLine("Pupils information:\n" + Show(list));
            Console.WriteLine();
            
            //удаление ученика по id
            Console.WriteLine("Delete pupil in database by id");
            Console.Write("Enter id pupil: ");
            id = Int32.Parse(Console.ReadLine());
            pupilDao.DeletePupil(id);
            list = pupilDao.GetAllPupils();
            Console.WriteLine("Pupils information:\n" + Show(list));
            
            //обновление информации об ученике по id
            Console.WriteLine("Update information pupil in database by id");
            Console.Write("Enter id pupil: ");
            id = Int32.Parse(Console.ReadLine());
            pupilDao.UpdatePupil(GetPupil(), id);
            list = pupilDao.GetAllPupils();
            Console.WriteLine("Pupils information:\n" + Show(list));

            list = pupilDao.GetAllPupils();
            
            Console.WriteLine("Average rating of all students: " + Manager.CalculateAvgRating(list));
            Console.WriteLine();

            Console.WriteLine("Students with min rating:\n" + Show(Manager.GetPupilsMinRating(list)));

            Console.WriteLine("Students with max rating:\n" + Show(Manager.GetPupilsMaxRating(list)));



        }
    }
}