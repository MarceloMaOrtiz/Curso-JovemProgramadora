using AlunosModels;
using AlunosServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunosServices.Serializers
{
    internal static class Serializer
    {
        public static CreateAlunoDto AlunoToCreateDto(Aluno aluno)
        {

            return new CreateAlunoDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Cpf = aluno.Cpf,
                Media = aluno.Media,
                Ativo = aluno.Ativo,
            };
        }

        public static Aluno CreateDtoToAluno(CreateAlunoDto dto)
        {
            return new Aluno
            {
                Id = dto.Id,
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento,
                Cpf = dto.Cpf,
                Media = dto.Media,
                Ativo = dto.Ativo,
            };
        }

        public static AlunoDto AlunoToDto(Aluno aluno)
        {

            return new AlunoDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Cpf = aluno.Cpf,
                Media = aluno.Media,
                Ativo = aluno.Ativo,
            };
        }

        public static Aluno DtoToAluno(AlunoDto dto)
        {
            return new Aluno
            {
                Id = dto.Id,
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento,
                Cpf = dto.Cpf,
                Media = dto.Media,
                Ativo = dto.Ativo,
            };
        }

        public static List<AlunoDto> AlunosToDtos(List<Aluno> alunos)
        {
            List<AlunoDto> dtos = new List<AlunoDto>();
            foreach (var aluno in alunos)
            {
                dtos.Add(AlunoToDto(aluno));
            }
            return dtos;
        }

        public static List<Aluno> DtosToAlunos(List<AlunoDto> dtos)
        {
            List<Aluno> alunos = new List<Aluno>();
            foreach (var dto in dtos)
            {
                alunos.Add(DtoToAluno(dto));
            }
            return alunos;
        }
    }
}
