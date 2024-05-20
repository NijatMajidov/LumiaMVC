using LumiaMVC.Business.Exceptions;
using LumiaMVC.Business.Services.Abstract;
using LumiaMVC.Core.Models;
using LumiaMVC.Core.RepositoryAbstract;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumiaMVC.Business.Services.Concretes
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamService(ITeamRepository teamRepository, IWebHostEnvironment webHostEnvironment)
        {
            _teamRepository = teamRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public void CreateTeam(Team team)
        {
            if (team == null) throw new EntityNullException("", "Entity null referance exception");
            if (team.ImgFile == null) throw new ImageFileNullException("ImgFile", "Image File Null referance exception!");
            if (!team.ImgFile.ContentType.Contains("image/")) throw new FileContentTypeException("ImgFile", "This file not Image");
            if (team.ImgFile.Length > 2097152) throw new FileSizeException("ImgFile", "File size exception. File < 2Mb!!!");

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(team.ImgFile.FileName);
            string path = _webHostEnvironment.WebRootPath + @"\uploads\teams\" + fileName;

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                team.ImgFile.CopyTo(stream);
            }
            team.ImgUrl = fileName;
            _teamRepository.Add(team);
            _teamRepository.Commit();
            
        }

        public void DeleteTeam(int id)
        {
            var delTeam = _teamRepository.Get(x=> x.Id == id);
            if (delTeam == null) throw new EntityNullException("","Team member not found");
            
            string path = _webHostEnvironment.WebRootPath + @"\uploads\teams\" +delTeam.ImgUrl;

            if(!File.Exists(path)) throw new ImageFileNotFoundException("ImgFile", "Image File Not Found!");
            File.Delete(path);
            _teamRepository.Delete(delTeam);
            _teamRepository.Commit();

        }

        public List<Team> GetAllTeams(Func<Team, bool>? func = null)
        {
            return _teamRepository.GetAll(func);
        }

        public Team GetTeam(Func<Team, bool>? func = null)
        {
            return _teamRepository.Get(func);
        }

        public void UpdateTeam(int id, Team newTeam)
        {
            var oldTeam = _teamRepository.Get(x => x.Id == id);
            if (oldTeam == null) throw new EntityNullException("", "Team member not found");

            if(newTeam == null) throw new EntityNullException("", "Entity null referance exception");
            if(newTeam.ImgFile != null)
            {
                string oldPath = _webHostEnvironment.WebRootPath + @"\uploads\teams\" + oldTeam.ImgUrl;
                if (!File.Exists(oldPath)) throw new ImageFileNotFoundException("ImgFile", "Image File Not Found!");
                File.Delete(oldPath);

                if (!newTeam.ImgFile.ContentType.Contains("image/")) throw new FileContentTypeException("ImgFile", "This file not Image");
                if (newTeam.ImgFile.Length > 2097152) throw new FileSizeException("ImgFile", "File size exception. File < 2Mb!!!");

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(newTeam.ImgFile.FileName);
                string path = _webHostEnvironment.WebRootPath + @"\uploads\teams\" + fileName;

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    newTeam.ImgFile.CopyTo(stream);
                }

                oldTeam.ImgUrl = fileName;
            }
            oldTeam.Name = newTeam.Name;
            oldTeam.Surname = newTeam.Surname;
            oldTeam.Position = newTeam.Position;
            oldTeam.Description = newTeam.Description;
            _teamRepository.Commit();

        }
    }
}
