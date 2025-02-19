
using Data.Context;
using Data.Entites;
using Data.Entities;
using Data.Interface;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class ProjectsRepository : IProjectRepositories
    {
        private readonly string _connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C-Projects\LOCALDB\LOCALDB\Data\database.mdf;Integrated Security=True;Connect Timeout=30";


        public ProjectsRepository() { }

        public void CreateUserTableIfNotExists()
        {
            try
            {
                string createUsersTableQuery = @"
                IF OBJECT_ID('Project', 'P') IS NULL

			CREATE TABLE Project (
            id int not null identity primary key,
            Name NVARCHAR(150) not null,
            Description NVARCHAR(max),
            StartDate date not null,
            EndDate date,
            StatusId int not null,
            UserId int not null
            )
                ";

                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using var command = new SqlCommand(createUsersTableQuery, connection);
                command.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        public bool Create(ProjectEntity projectEntity)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO Project (ProductName, Description, StartDate, EndDate, StatusId, UserId) 
                    VALUES (@ProductName, @Description, @StartDate, @EndDate, @StatusId, @CustomerId, @UserId)
                 ";

                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using var command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@ProjectName", projectEntity.ProjectName);
                command.Parameters.AddWithValue("@Description", projectEntity.Description);
                command.Parameters.AddWithValue("@StartDate", projectEntity.StartDate);
                command.Parameters.AddWithValue("@EndDate", projectEntity.EndDate);
                command.Parameters.AddWithValue("@StatusId", projectEntity.StatusId);
                command.Parameters.AddWithValue("@UserId", projectEntity.UserId);


                command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<ProjectEntity> GetAll()
        {
            try
            {
                var projects = new List<ProjectEntity>();

                string selectQuery = @"
                    SELECT * FROM Project
                 ";

                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using var command = new SqlCommand(selectQuery, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    projects.Add(new ProjectEntity
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        ProjectName = reader.GetString(2),
                        Description = reader.GetString(3),
                        StartDate = reader.GetString(4),
                        EndDate = reader.GetString(5),
                        StatusId = reader.GetString(6)
                    });
                }

                return projects;
            }
            catch
            {
                return null!;

            }

        }

        //private readonly DataContext _context = context;

        public async Task<UserEntity> CreateAsync(ProjectEntity entity)
        {
            throw new NotImplementedException();
            //if (entity == null)
            //    return null!;

            //try
            //{
            //    await _context.Project.AddAsync(entity);
            //}
            //catch (Exception ex) 
            //{
            //   Debug.WriteLine($"Error creating project entity :: {ex.Message}");

            //}
        }

        public Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> UpdateAsync(Expression<Func<ProjectEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> UpdateAsync(ProjectEntity updateEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<ProjectEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}

