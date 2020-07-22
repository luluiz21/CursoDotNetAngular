using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CursoAngularDotNet_WebAPI.Data{

    public class Repository : IRepository{
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Departamento[]> GetAllDepartamentosAsync()
        {
            IQueryable<Departamento> query = _context.Departamentos;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Departamento[]> GetDepartamentosAsyncByFuncionarioId(int FuncionarioIdDepartamento)
        {
            IQueryable<Departamento> query = _context.Departamentos;


            query = query.AsNoTracking()
                         .OrderBy(departamento => departamento.Id)
                         .Where(departamento => departamento.Id == FuncionarioIdDepartamento);

            return await query.ToArrayAsync();
        }

        public async Task<Departamento> GetDepartamentoAsyncById(int DepartamentoId)
        {
            IQueryable<Departamento> query = _context.Departamentos;


            query = query.AsNoTracking()
                         .OrderBy(departamento => departamento.Id)
                         .Where(departamento => departamento.Id == DepartamentoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Funcionario[]> GetAllFuncionarioesAsync()
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioAsyncById(int FuncionarioId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;


            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.Id)
                         .Where(funcionario => funcionario.Id == FuncionarioId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Funcionario[]> GetFuncionarioesAsyncByDepartamentoId(int DepartamentoId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;


            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.Id)
                         .Where(funcionario => funcionario.IdDepartamento == DepartamentoId);

            return await query.ToArrayAsync();
        }

    }

}

/*
        

        public async Task<Funcionario[]> GetFuncionariosAsyncByDepartamentoId(int departamentoId, bool includeDepartamento)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeDepartamento)
            {
                query = query.Include(p => p.Departamentos);
            }

            query = query.AsNoTracking()
                         .OrderBy(departamento => departamento.Id)
                         .Where(departamento => departamento.Departamentos.Any(d => 
                            d.DepartamentosDepartamentos.Any(ad => ad.DepartamentoId == departamentoId)));

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario[]> GetAllFuncionariosAsync(bool includeDepartamentos = true)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeDepartamentos)
            {
                query = query.Include(c => c.Departamentos);
            }

            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Funcionario> GetFuncionarioAsyncById(int FuncionarioId, bool includeDepartamentos = true)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeDepartamentos)
            {
                query = query.Include(pe => pe.Departamentos);
            }

            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.Id)
                         .Where(funcionario => funcionario.Id == funcionarioId);

            return await query.FirstOrDefaultAsync();
        }*/