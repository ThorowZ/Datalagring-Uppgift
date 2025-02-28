using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();


    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        ProjectName = form.ProjectName,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
       
    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        ProjectName = entity.ProjectName,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate
    };
    public static ProjectUpdateForm Create(Project project) => new()
    {
        Id = project.Id,
        ProjectName = project.ProjectName,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate
    };

    public static ProjectEntity Create(ProjectUpdateForm form) => new()
    {
        Id = form.Id,
        ProjectName = form.ProjectName,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate
    };

}
