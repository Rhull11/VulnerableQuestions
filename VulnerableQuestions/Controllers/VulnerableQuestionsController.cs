using Microsoft.AspNetCore.Mvc;
using VulnerableQuestions.Models;
using VulnerableQuestions.Services;

namespace VulnerableQuestions.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VulnerableQuestionsController : Controller
{
    private readonly VulnerableQuestionsService _vqService;

    public VulnerableQuestionsController(VulnerableQuestionsService vqService) =>
        _vqService = vqService;

    /// <summary>
    /// Gets all vulnerable questions
    /// </summary>
    [HttpGet]
    public async Task<List<VulnerableQuestion>> Get() =>
        await _vqService.GetAsync();
    
    /// <summary>
    /// Gets a vulnerable question by id.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<VulnerableQuestion>> Get(string id)
    {
        var questions = await _vqService.GetAsync(id);
        if (questions is null)
        {
            return NotFound();
        }

        return questions;
    }
}