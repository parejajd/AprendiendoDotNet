using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tasker.Models;

namespace Tasker.Mobile.Services
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<MyTask>> GetTasks()
        {
            List<MyTask> tasksList = new List<MyTask>();

            var uri = new Uri("http://tasker.creapps.co/api/Task/Tasks");

            try
            {
                var respuesta = await _client.GetAsync(uri);

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    tasksList = JsonConvert.DeserializeObject<List<MyTask>>(contenido);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return tasksList;
        }

        public async Task<List<Project>> GetProjects()
        {
            List<Project> projectList = new List<Project>();

            var uri = new Uri("http://tasker.creapps.co/api/Task/Projects");

            try
            {
                var respuesta = await _client.GetAsync(uri);

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    projectList = JsonConvert.DeserializeObject<List<Project>>(contenido);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return projectList;
        }
    }
}
