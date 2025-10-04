using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto.Serializers
{
    public static class AlunoSerializer
    {
        public static AlunoDto AlunoToDto(Aluno aluno)
        {
            return new AlunoDto()
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Cpf = aluno.Cpf,
                Media = aluno.Media,
                Ativo = aluno.Ativo
            };
        }

        public static Aluno DtoToAluno(AlunoDto alunoDto)
        {
            return new Aluno()
            {
                Id = alunoDto.Id,
                Nome = alunoDto.Nome,
                DataNascimento = alunoDto.DataNascimento,
                Cpf = alunoDto.Cpf,
                Media = alunoDto.Media,
                Ativo = alunoDto.Ativo
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
