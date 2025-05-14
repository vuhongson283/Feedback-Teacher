namespace PRN231_FinalProject.Dtos
{
    public class FeedbackRequestDto
    {
        public int StudentId { get; set; }
        public int FormId { get; set; }
        
         
        public List<FeedbackAnswerDto> Answers { get; set; }
    }
}
