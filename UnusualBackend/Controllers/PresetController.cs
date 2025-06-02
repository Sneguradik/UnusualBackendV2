using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnusualBackend.Dto.Presets;
using UnusualBackend.Models.UsersSettings;

namespace UnusualBackend.Controllers
{
    [Route("presets")]
    [ApiController]
    public class PresetController : ControllerBase
    {
        [HttpPost]
        public async Task CreatePreset([FromBody] CreatePresetDto dto)
        {
            
        }

        [HttpDelete("{id}")]
        public async Task DeletePreset(int id)
        {
            
        }
        
        [HttpGet("{id}")]
        public as
    }
}
