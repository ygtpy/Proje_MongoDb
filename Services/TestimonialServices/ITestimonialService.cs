using AkademiQMongoDb.DTOs.TestimonialDtos;

namespace AkademiQMongoDb.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllAsync();
        Task CreateAsync(CreateTestimonialDto testimonialDto);
        Task UpdateAsync(UpdateTestimonialDto testimonialDto);
        Task DeleteAsync(string id);
        Task<UpdateTestimonialDto> GetByIdAsync(string id);
    }
}
