using Data.Context;
using Data.Entites;
using Data.Entities;

namespace Business.Services
{
    public class ProjectService(DataContext context)
    {
        private readonly DataContext _context = context;

        public ProjectEntity CreateProject(ProjectEntity projectEntity)
        {
            _context.Projects.Add(projectEntity);
            _context.SaveChanges();

            return projectEntity;
        }

        public IEnumerable<ProjectEntity> GetProjects()
        {
            return _context.Projects;
        }

        public ProjectEntity GetProjectById(int id)
        {
            var projectEntity = _context.Projects.FirstOrDefault(x => x.Id == id);

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

            return false;
        }
    }
}
