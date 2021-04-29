using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace Model.Entity
{
    public class SqlPupilDAO : SqlAbstractDAO, IPupilDAO
    {
        private const string SELECT_ALL_PUPILS = "SELECT * FROM Pupil";
        private const string SELECT_PUPIL = "SELECT * FROM Pupil WHERE pupil_id = @id";

        private const string INSERT_PUPIL =
            "INSERT INTO Pupil(surname, name, passport, birthday, rating) VALUES (@surname, @name, @passport, @birthday, @rating)";

        private const string UPDATE_PUPIL =
            "UPDATE Pupil SET surname = @surname, name = @name, passport = @passport, birthday = @birthday, rating = @rating WHERE pupil_id = @id";

        private const string DELETE_PUPIL = "DELETE FROM Pupil WHERE pupil_id = @id";
        private const string SELECT_COUNT = "SELECT count(pupil_id) FROM Pupil";
        private const string MSG_NOT_PUPIL_GIVEN_ID_IN_DATABASE = "Pupil with given id is not present in database";

        public IList<Pupil> GetAllPupils()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_ALL_PUPILS, connection);
            SqlDataReader reader = command.ExecuteReader();
            IList<Pupil> list = new List<Pupil>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Pupil pupil = new Pupil();
                    pupil.Surname = reader.GetString(1);
                    pupil.Name = reader.GetString(2);
                    pupil.Passport = reader.GetString(3);
                    pupil.Birthday = reader.GetDateTime(4);
                    pupil.Rating = reader.GetFloat(5);
                    list.Add(pupil);
                }
            }

            ReleaseConnection(connection);
            return list;
        }

        public Pupil GetPupil(int id)
        {
            SqlConnection connection = null;

            connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_PUPIL, connection);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.SqlDbType = SqlDbType.Int;
            idParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(idParam);

            SqlDataReader reader = command.ExecuteReader();

            Pupil pupil = new Pupil();

            if (reader.HasRows)
            {
                reader.Read();
                pupil.Surname = reader.GetString(1);
                pupil.Name = reader.GetString(2);
                pupil.Passport = reader.GetString(3);
                pupil.Birthday = reader.GetDateTime(4);
                pupil.Rating = reader.GetFloat(5);
            }

            ReleaseConnection(connection);
            return pupil;
        }

        public void InsertPupil(Pupil pupil)
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(INSERT_PUPIL, connection);

            SqlParameter surnameParam = new SqlParameter();
            surnameParam.Value = pupil.Surname;
            surnameParam.SqlDbType = SqlDbType.NVarChar;
            surnameParam.ParameterName = "@surname";
            surnameParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(surnameParam);
            
            SqlParameter nameParam = new SqlParameter();
            nameParam.Value = pupil.Name;
            nameParam.SqlDbType = SqlDbType.NVarChar;
            nameParam.ParameterName = "@name";
            nameParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(nameParam);
            
            SqlParameter passportParam = new SqlParameter();
            passportParam.Value = pupil.Passport;
            passportParam.SqlDbType = SqlDbType.NVarChar;
            passportParam.ParameterName = "@passport";
            passportParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(passportParam);
            
            SqlParameter birthdayParam = new SqlParameter();
            birthdayParam.Value = pupil.Birthday;
            birthdayParam.SqlDbType = SqlDbType.DateTime;
            birthdayParam.ParameterName = "@birthday";
            birthdayParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(birthdayParam);
            
            SqlParameter ratingParam = new SqlParameter();
            ratingParam.Value = pupil.Rating;
            ratingParam.SqlDbType = SqlDbType.Float;
            ratingParam.ParameterName = "@rating";
            ratingParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(ratingParam);

            command.ExecuteNonQuery();
            ReleaseConnection(connection);
        }

        public void DeletePupil(int id)
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(DELETE_PUPIL, connection);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.SqlDbType = SqlDbType.Int;
            idParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(idParam);

            command.ExecuteNonQuery();
            ReleaseConnection(connection);
        }

        public void UpdatePupil(Pupil pupil, int id)
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(UPDATE_PUPIL, connection);
            
            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.SqlDbType = SqlDbType.Int;
            idParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(idParam);

            SqlParameter surnameParam = new SqlParameter();
            surnameParam.Value = pupil.Surname;
            surnameParam.SqlDbType = SqlDbType.NVarChar;
            surnameParam.ParameterName = "@surname";
            surnameParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(surnameParam);
            
            SqlParameter nameParam = new SqlParameter();
            nameParam.Value = pupil.Name;
            nameParam.SqlDbType = SqlDbType.NVarChar;
            nameParam.ParameterName = "@name";
            nameParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(nameParam);
            
            SqlParameter passportParam = new SqlParameter();
            passportParam.Value = pupil.Passport;
            passportParam.SqlDbType = SqlDbType.NVarChar;
            passportParam.ParameterName = "@passport";
            passportParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(passportParam);
            
            SqlParameter birthdayParam = new SqlParameter();
            birthdayParam.Value = pupil.Birthday;
            birthdayParam.SqlDbType = SqlDbType.DateTime;
            birthdayParam.ParameterName = "@birthday";
            birthdayParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(birthdayParam);
            
            SqlParameter ratingParam = new SqlParameter();
            ratingParam.Value = pupil.Rating;
            ratingParam.SqlDbType = SqlDbType.Float;
            ratingParam.ParameterName = "@rating";
            ratingParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(ratingParam);

            command.ExecuteNonQuery();
            ReleaseConnection(connection);
        }
        
        public int GetCountPupil()
        {
            SqlConnection connection = (SqlConnection) GetConnection();
            SqlCommand command = new SqlCommand(SELECT_COUNT, connection);
            int count = (int)command.ExecuteScalar();
            ReleaseConnection(connection);
            return count;
        }
    }
}