using Data.Entities;
using Business.Dtos;
using Business.Models;

namespace Data.Interface
{


    public interface IProjectService
    {
        ProjectEntity CreateProject(ProjectRegistrationForm form);

        //IEnumerable<ProjectEntity> GetAllProjects();

        IEnumerable<Project> GetAllProjects();

        ProjectEntity GetProjectByName(string projectName);
        ProjectEntity GetProjectById(int id);



        ProjectEntity UpdateProject(ProjectEntity projectEntity);

        bool DeleteProjectById(int id);
    }
}