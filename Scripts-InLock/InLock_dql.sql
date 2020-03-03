use InLock_Games_Manha_Tarde

--SELECT Usuario.NomeUsuario, Usuario.Email,Usuario.DataNascimento,Usuario.Genero,TipoUsuario.TituloTipoUsuario
--FROM Usuario
--INNER JOIN TipoUsuario ON  Usuario.IdUsuario =TipoUsuario.IdTipoUsuario


--SELECT Instituicao.CNPJ,Instituicao.Endereco,Instituicao.NomeFantasia
--FROM Instituicao

--SELECT TipoEvento.TituloTipoEvento
--FROM TipoEvento

--SELECT Evento.NomeEvento,Evento.DataEvento,Evento.AcessoLivre,Evento.Descricao,TipoEvento.TituloTipoEvento,
--Instituicao.CNPJ,Instituicao.Endereco,Instituicao.NomeFantasia
--FROM Evento
--INNER JOIN  TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento
--INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao--

select Jogos.NomeJogo,Jogos.IdEstudio
from Jogos

select Estudios.NomeEstudio,Jogos.NomeJogo
from Estudios
inner join Jogos on Estudios.IdEstudio = Jogos.IdEstudio


select Jogos.NomeJogo
from Jogos
where IdJogo= 1

select Usuario.Email,Usuario.Senha,Usuario.IdUsuario,Usuario.IdTipoUsuario
from Usuario
where Email= 'admin@admin.com'

select * from Jogos

select * from Estudios