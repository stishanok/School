using System.Collections.Generic;

namespace Model.Entity
{
    public interface IPupilDAO
    {
        IList<Pupil> GetAllPupils();
        Pupil GetPupil(int id);
        void InsertPupil(Pupil pupil);
        void UpdatePupil(Pupil pupil, int id);
        void DeletePupil(int id);
        int GetCountPupil();
    }
}