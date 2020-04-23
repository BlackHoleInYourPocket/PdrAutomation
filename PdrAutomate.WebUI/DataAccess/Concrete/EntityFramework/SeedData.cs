using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PdrAutomate.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			var context = app.ApplicationServices.GetRequiredService<PdrAutomateContext>();

			context.Database.Migrate();
			if (!context.Students.Any())
			{
				var Classes = new[]
				{
					new Class()
					{
						ClassName="10A",
						ClassCapacity=20
					},
					new Class()
					{
						ClassName="10B",
						ClassCapacity=20
					},
				};
				context.AddRange(Classes);

				var Presentations = new[]
				{
					new Presentation()
					{
						PresentationName="Bilgisayar",
					},
					new Presentation()
					{
						PresentationName="Kimya",
					},
				};
				context.AddRange(Presentations);

				var Sessions = new[]
				{
					new Sessions()
					{
						StartTime=new DateTime(2020,02,02,9,0,0),
						EndTime =new DateTime(2020,02,02,9,0,0)
					},
					new Sessions()
					{
						StartTime=new DateTime(2020,02,02,10,0,0),
						EndTime =new DateTime(2020,02,02,11,0,0)
					},
				};
				context.AddRange(Sessions);

				var Students = new[]
				{
					new Student()
					{
						StudentName="Seyfi",
						StudentSurname="Zeyrek",
						StudentSchoolId="55",
						Password="seyf1903",
						Class=Classes[0]
					}
				};
				context.AddRange(Sessions);

				var PresentationSessions = new[]
				{
					new PresentationSession()
					{
						Presentation=Presentations[0],
						Sessions=Sessions[0]
					},
					new PresentationSession()
					{
						Presentation=Presentations[0],
						Sessions=Sessions[1]
					},
					new PresentationSession()
					{
						Presentation=Presentations[1],
						Sessions=Sessions[0]
					},
					new PresentationSession()
					{
						Presentation=Presentations[1],
						Sessions=Sessions[1]
					},

				};
				context.AddRange(PresentationSessions);

				var ClassPresentationSession = new[]
				{
					new ClassPresentationsession()
					{
						Class=Classes[0],
						Presentation=Presentations[0],
						Sessions=Sessions[0],
						CurrentCapacity=0
					},
					new ClassPresentationsession()
					{
						Class=Classes[0],
						Presentation=Presentations[1],
						Sessions=Sessions[1],
						CurrentCapacity=0

					},
					new ClassPresentationsession()
					{
						Class=Classes[1],
						Presentation=Presentations[0],
						Sessions=Sessions[1],
						CurrentCapacity=0
					},
					new ClassPresentationsession()
					{
						Class=Classes[1],
						Presentation=Presentations[1],
						Sessions=Sessions[0],
						CurrentCapacity=0
					},
				};

				context.AddRange(ClassPresentationSession);

				var StudentPresentationSessions = new[]
				{
					new StudentPresentationsession()
					{
						Student=Students[0],
						Presentation=Presentations[0],
						Sessions=Sessions[0]
					}
				};
				context.AddRange(StudentPresentationSessions);
				context.SaveChanges();
			}

			if (!context.Questionnaries.Any())
			{
				var BeforePresentationQuestions = new List<Question>()
				{
					new Question()
					{
						QuestionName="Meslek seçimi ve karar verme sürecinde kariyer günü etkinliğimizi önemsiyorum.",
						IsCheckbox=true

					},
					new Question()
					{
						QuestionName="Gelecekte hangi mesleği seçeceğime karar verdim.",
						IsCheckbox=true

					},
					new Question()
					{
						QuestionName="Ders çalışma motivasyonu konusunda kendimi yeterli buluyorum.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Kariyer gününde meslekler hakkında kafamdaki merak ettiğim soruların cevabını bulabileceğime inanıyorum.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Seçmeyi düşündüğüm meslekler hakkında fikir sahibiyim.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Kendimi başarılı bir öğrenci olarak görüyorum.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Kariyer gününde dinleyeceğim meslek tanıtım sunumunu elle seçim yerine internet ortamında seçebiliyor olmamı olumlu buluyorum.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="İnternet ortamındaki sunum seçim uygulamasını kolaylıkla kullanabildim.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Bunların dışında varsa eklemek istediğiniz görüşlerinizi yazınız.",
						IsCheckbox=false
					}
				};
				context.AddRange(BeforePresentationQuestions);

				var BeforePresentationQuestionnarie = new Questionnarie()
				{
					QuestionnarieName = "Sunum Öncesi",
					IsSentiment = false,
					Questions = BeforePresentationQuestions
				};
				context.AddRange(BeforePresentationQuestionnarie);

				var AfterPresentationQuestions = new List<Question>()
				{
					new Question()
					{
						QuestionName="Meslek seçimi ve karar verme sürecinde kariyer günü etkinliğimizi önemsiyorum.",
						IsCheckbox=true

					},
					new Question()
					{
						QuestionName="Gelecekte hangi mesleği seçeceğime karar verdim.",
						IsCheckbox=true

					},
					new Question()
					{
						QuestionName="Ders çalışma motivasyonu konusunda kendimi yeterli buluyorum.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Kariyer gününde meslekler hakkında kafamdaki merak ettiğim soruların cevabını bulabileceğime inanıyorum.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Seçmeyi düşündüğüm meslekler hakkında fikir sahibiyim.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Kendimi başarılı bir öğrenci olarak görüyorum.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Kariyer gününde dinleyeceğim meslek tanıtım sunumunu elle seçim yerine internet ortamında seçebiliyor olmamı olumlu buluyorum.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="İnternet ortamındaki sunum seçim uygulamasını kolaylıkla kullanabildim.",
						IsCheckbox=true
					},
					new Question()
					{
						QuestionName="Bunların dışında varsa eklemek istediğiniz görüşlerinizi yazınız.",
						IsCheckbox=false
					}
				};
				context.AddRange(AfterPresentationQuestions);

				var AfterPresentationQuestionnarie = new Questionnarie()
				{
					QuestionnarieName = "Sunum Sonrası",
					IsSentiment = false,
					Questions = AfterPresentationQuestions
				};
				context.AddRange(AfterPresentationQuestionnarie);

				var BeierQuestions = new List<Question>()
				{
				  new Question()
				  {
						QuestionName="Büyüdüğüm zaman",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Arkadaşlar",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Yaramazlık yaptığım zaman",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Okulda",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Bir türlü unutmadığım",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="İyi arkadaşlar",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Evimiz",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Annelerin en iyisi",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Geçen sene",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Elimden gelseydi",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Benim en iyi",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Öğretmenler",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Annemi severim ama",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Canım sıkılınca",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Pişman olduğum",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Ailem",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Bana göre okul",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Arkadaş olarak hoşlandığım kimseler",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Bazen babam",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Eskiden",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Başkalarına göre",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Keşke annem",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="İşlerin başında ben olsaydım",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="En büyük üzüntüm",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Tahsilimi bitirsem",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Babaların iyisi",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Yapmamam gereken",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Kardeşlerim",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="En çok istediğim",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Beceremediğim şey",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Hayatın en kötü tarafı",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Eğer annem",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Sıkıntıda olduğum zaman arkadaşlarım",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Cezalar ve yasaklar",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Kurtulmak istediğim üzüntü",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Kötü bir baba",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Yaptığım en kötü şey",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="İyi öğretmenlerin yapması gereken",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Evde her şey",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Hatırımda kalan",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Beni en çok endişelendiren şey",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Dileğim",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Annem",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Çocuklar",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Eğer babam",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Korktuğum şey",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Ben küçükken",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Büyükler",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Vazgeçebilsem",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Ders kitaplarını kapatınca",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Vücudum",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Babam ve ben",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Kendi evim olunca",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Yalnız kalınca",
						IsCheckbox=false
				  },
				  new Question()
				  {
						QuestionName="Hayatta olmak istediğim şey",
						IsCheckbox=false
				  }
				};
				context.AddRange(BeierQuestions);

				var BeierQuestionnarie = new Questionnarie()
				{
					QuestionnarieName = "Beier Anketi",
					IsSentiment = true,
					Questions = BeierQuestions
				};

				context.AddRange(BeierQuestionnarie);

				context.SaveChanges();
			}

		}
	}
}
