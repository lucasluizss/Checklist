using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Checklist.Models;

namespace Checklist.Business
{
    public class TasksBusiness
    {
        private checklistEntities checkListDB = new checklistEntities();

        public tasks NewTask(tasks newTask)
        {
            if (string.IsNullOrEmpty(newTask.Description))
            {
                throw new Exception("Favor preencher a descrição da tarefa.");
            }

            //Quando criada uma tarefa ela recebe o estado true (Em andamento)
            newTask.Estate = true;

            try
            {
                checkListDB.tasks.Add(newTask);

                checkListDB.SaveChanges();

                return newTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Editar aqui
        public tasks ChangeStatusTask(tasks statusTarefa)
        {
            //Lambda para buscar uma tarefa pelo ID
            var task = (checkListDB.tasks.Where(c => c.IdTask == statusTarefa.IdTask).Select(c => c)).FirstOrDefault();
            
            //Se tarefa estiver em andamento, será mudada para pronta. Senão vice-versa
            if (task.Estate == true)
            {
                task.Estate = false;
            }
            else
            {
                task.Estate = true;
            }

            try
            {
                checkListDB.tasks.Attach(task);
                checkListDB.Entry(task).Property(x => x.Estate).IsModified = true;
                checkListDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return statusTarefa;
        }

    }
}