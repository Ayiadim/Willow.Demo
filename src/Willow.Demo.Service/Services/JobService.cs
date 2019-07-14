namespace Willow.Demo.Service.Services
{
    using AutoMapper;
    using Data;
    using Data.Repositories;
    using Entities;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJobService
    {
        Task<GetJobsQueryResponse> GetAsync(Guid jobId);

        Task<GetJobsQueryResponse> GetAllAsync();

        Task<UpdateJobStatusCommandResponse> UpdateStatusAsync(Job job);
    }

    public class JobService : IJobService
    {
        private readonly IRxJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IRxJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<GetJobsQueryResponse> GetAsync(Guid jobId)
        {
            var rxJob = await _jobRepository.GetAsync(jobId);

            var job = _mapper.Map<RxJob, Job>(rxJob);

            return new GetJobsQueryResponse
            {
                Success = true,
                Items = new List<Job> { job }
            };
        }

        public async Task<GetJobsQueryResponse> GetAllAsync()
        {
            var rxJobs = await _jobRepository.GetAllAsync();

            var items = new List<Job>();

            foreach (var rxJob in rxJobs)
            {
                items.Add(_mapper.Map<RxJob, Job>(rxJob));
            }

            return new GetJobsQueryResponse
            {
                Success = true,
                Items = items
            };
        }

        public async Task<UpdateJobStatusCommandResponse> UpdateStatusAsync(Job job)
        {
            var rxJob = await _jobRepository.GetAsync(job.Id);

            // note: should add these statuses to an enum
            if (rxJob.Status == "In Progress" || rxJob.Status == "Delayed") {
                rxJob.Status = "Complete";

                await _jobRepository.UpdateAsync(rxJob);

                return new UpdateJobStatusCommandResponse
                {
                    Success = true,
                    Items = new List<Job> { _mapper.Map<RxJob, Job>(rxJob) }
                };
            }

            return new UpdateJobStatusCommandResponse
            {
                Success = false,
                Message = "Job is neither in progress nor delayed"
            };
        }
    }
}
