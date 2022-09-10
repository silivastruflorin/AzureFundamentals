namespace AzureBlobProject.Services
{
    public interface IContainerService
    {
        Task<List<string>> GetAllContainerAndBlobs();
        Task<List<string>> GetAllContainer();
        Task DeleteContainer(string containerName);
        Task CreateContainer(string containerName);
    }
}
