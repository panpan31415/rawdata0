using portfolio2gr4.Models;

namespace WebService.Models
{
	public class QuestionModel : PostModel
	{
		public string Title { get; set; }
		public int AcceptedAnswerId { get; set; }
		public AnswerModel[] Answers { get; set; }
	}
}