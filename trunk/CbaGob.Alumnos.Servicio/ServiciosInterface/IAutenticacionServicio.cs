﻿namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IAutenticacionServicio
    {
        void SignIn(string userName, string Userdata);
        void SignOut();
        string GetUserData();
    }
}
