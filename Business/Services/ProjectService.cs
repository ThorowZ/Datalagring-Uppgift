using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Context;
using Data.Entities;
using Data.Interface;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ProjectService(DataContext context, IStatusTypesService statusService, IProjectRepositories projectRepositories) : IProjectService
    {
        private readonly DataContext _context = context;
        private readonly IStatusTypesService _statusService = statusService;
        private readonly IProjectRepositories _projectRepositories = projectRepositories;

        public ProjectEntity CreateProject(ProjectRegistrationForm form)
        {

            // Tagit hjälp av ChatGPT
            var statusEntity = _context.StatusTypes.FirstOrDefault(s => s.StatusName == form.StatusName);
            if (statusEntity == null)
            {
                statusEntity = new StatusTypesEntity { StatusName = form.StatusName };
                _context.StatusTypes.Add(statusEntity);
                _context.SaveChanges();
            }

            var userEntity = _context.Users.FirstOrDefault(u => u.Id == form.UserId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException("User not found");
            }


            var projectEntity = new ProjectEntity
            {
                ProjectName = form.ProjectName,
                Description = form.Description,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                Status = statusEntity,
                User = userEntity
            };

            _context.Projects.Add(projectEntity);
            _context.SaveChanges();

            return projectEntity;
        }

        public async Task<Project> CreateProjectAsync(ProjectRegistrationForm form)
        {
            var entity = await _projectRepositories.GetAsync(x => x.ProjectName == form.ProjectName);
            entity ??= await _projectRepositories.CreateAsync(ProjectFactory.Create(form));

                return ProjectFactory.Create(entity);
        }

        public async Task<IEnumerable<Project>> GetAllProjectAsync()
        {
            var entities = await _projectRepositories.GetAllAsync();
            var projects = entities.Select(ProjectFactory.Create);
            return projects ?? [];
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var entity = await _projectRepositories.GetAsync(x => x.Id == id);
            var project = ProjectFactory.Create(entity);
            return project ?? null!;

        }

        public async Task<Project> GetProjectByNameAsync(string projectName)
        {
            var entity = await _projectRepositories.GetAsync(x => x.ProjectName == projectName);
            var project = ProjectFactory.Create(entity);
            return project ?? null!;

        }

        public async Task<Project> UpdateProjectAsync(ProjectUpdateForm form)
        {
            var entity = await _projectRepositories.UpdateAsync(ProjectFactory.Create(form));
            var project = ProjectFactory.Create(entity);
            return project ?? null!;
        }


        public async Task<bool> DeleteProjectAsync(int id)
        {
            var result = await _projectRepositories.DeleteAsync(x => x.Id == id);
            return result;
        }



        public IEnumerable<Project> GetAllProjects()
        {


            var entities = _context.Projects.

                Include(x => x.User).
                Include(x => x.Status)
                //Tagit hjälp av ChatGpt. Bättre läsbarhet och effektivt .
                .Select(p => new Project
                //    .ToList();
                //entities.ForEach(p => projects.Add(new Project
                {
                Id = p.Id,
                ProjectName = p.ProjectName,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                StatusName = p.Status.StatusName,
                UserFirstName = p.User.FirstName,
                UserLastName = p.User.LastName
            })

            .ToList();

            return entities;
        }


        //public IEnumerable<ProjectEntity> GetAllProjects()
        //{
        //    var projects = _context.Projects.Include(x => x.User).ToList();

        //    return projects;
        //}


        public ProjectEntity GetProjectById(int id)
        {
            var projectEntity = _context.Projects.FirstOrDefault(x => x.Id == id);

            return projectEntity ?? null!;
        }

        public ProjectEntity GetProjectByName(string projectName)
        {
            var projectEntity = _context.Projects.FirstOrDefault(x => x.ProjectName == projectName);
            return projectEntity ?? null!;
        }

        public ProjectEntity UpdateProject(ProjectEntity projectEntity)
        {
            _context.Projects.Update(projectEntity);
            _context.SaveChanges();

            return projectEntity;
        }

        public bool DeleteProjectById(int id)
        {
            var projectEntity = _context.Projects.FirstOrDefault(x => x.Id == id);
            if (projectEntity != null)
            {
                _context.Remove(projectEntity);
                _context.SaveChanges();

                return true;
            }

            else { return false; }
        }
    }
}
