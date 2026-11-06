using eClavijoA.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace eClavijoA.Repositories
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection _conn;
        
        public string StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (_conn is not null)
                return;
            _conn = new (_dbPath);
            _conn.CreateTable<Models.Persona>();
        }

        //INSERT
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("nombre requerido");
                Persona persona = new Persona { Name = name };
                result = _conn.Insert(persona);
                StatusMessage = string.Format("DATOS GUARDADOS CON EXITO {0}", result);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        //select
        public List<Persona> GetAllPersonas()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                throw;
                StatusMessage = string.Format("Fallo. {0}", ex.Message);
            }
            return new List<Persona>();
        }

        //DELETE
        public void DeletePerson(int id)
        {
            try
            {
                Init();

                var persona = _conn.Table<Persona>()
                                  .FirstOrDefault(p => p.Id == id);

                if (persona != null)
                {
                    _conn.Delete(persona);
                    StatusMessage = $"REGISTRO {id} ELIMINADO";
                }
                else
                {
                    StatusMessage = $"No existe el ID {id}";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        //UPDATE
        public void UpdatePerson(int id, string name)
        {
            try
            {
                Init();
                var persona = _conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (persona != null)
                {
                    persona.Name = name;
                    _conn.Update(persona);
                    StatusMessage = string.Format("DATOS ACTUALIZADOS {0}", id);
                }
            }
            catch (Exception ex)
            {
                throw;
                StatusMessage = string.Format("Fallo al actualizar. {0}", ex.Message);
            }
        }

    }
}
