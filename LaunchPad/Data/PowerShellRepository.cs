﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaunchPad.Models;
using Microsoft.EntityFrameworkCore;

namespace LaunchPad.Data
{
    // Todo: Finish implementing interface with EF
    public class PowerShellRepository : IScriptRepository
    {
        private ApplicationDbContext _context;

        public PowerShellRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Scripts
        public IQueryable<Script> GetScripts()
        {
            return _context.Scripts;
        }

        public Script GetScriptById(int scriptId)
        {
            return _context.Scripts.FirstOrDefault(s => s.Id == scriptId);
        }

        public void InsertScript(Script script)
        {
            _context.Scripts.Add(script);
        }

        public void UpdateScript(Script script)
        {
            _context.Entry(script).State = EntityState.Modified;
        }

        public void DeleteScript(int scriptId)
        {
            var script = GetScriptById(scriptId);
            _context.Scripts.Remove(script);
        }


        // Jobs
        public IQueryable<Job> GetJobs()
        {
            return _context.Jobs;
        }

        public Job GetJobById(int jobId)
        {
            return _context.Jobs.FirstOrDefault(j => j.Id == jobId);
        }

        public void InsertJob(Job job)
        {
            _context.Jobs.Add(job);
        }
        
        public void UpdateJob(Job job)
        {
            _context.Entry(job).State = EntityState.Modified;
        }

        public void DeleteJob(int jobId)
        {
            var job = GetJobById(jobId);
            _context.Jobs.Remove(job);
        }


        public void Save()
        {
            _context.SaveChanges(); // TODO: Look into SaveChangesAsync
        }
    }
}
