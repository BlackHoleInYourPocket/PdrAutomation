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
						StudentSchoolId="2015510076",
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
				var BeforePresentationQuestionnarie = new Questionnarie()
				{
					QuestionnarieName = "Before",
					IsSentiment = false
				};
				context.AddRange(BeforePresentationQuestionnarie);

				var Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeforePresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Meslek seçimi ve karar verme sürecinde kariyer günü etkinliğimizi önemsiyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeforePresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Gelecekte hangi mesleği seçeceğime karar verdim.",
						IsCheckbox = true
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeforePresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Ders çalışma motivasyonu konusunda kendimi yeterli buluyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeforePresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kariyer gününde meslekler hakkında kafamdaki merak ettiğim soruların cevabını bulabileceğime inanıyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeforePresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Seçmeyi düşündüğüm meslekler hakkında fikir sahibiyim.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeforePresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kendimi başarılı bir öğrenci olarak görüyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeforePresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kariyer gününde dinleyeceğim meslek tanıtım sunumunu elle seçim yerine internet ortamında seçebiliyor olmamı olumlu buluyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeforePresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "İnternet ortamındaki sunum seçim uygulamasını kolaylıkla kullanabildim.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeforePresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Bunların dışında varsa eklemek istediğiniz görüşlerinizi yazınız.",
						IsCheckbox = false,
					}
				};
				context.AddRange(Q);

				var AfterPresentationQuestionnarie = new Questionnarie()
				{
					QuestionnarieName = "After",
					IsSentiment = false
				};
				context.AddRange(AfterPresentationQuestionnarie);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = AfterPresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Meslek seçimi ve karar verme sürecinde kariyer günü etkinliğimizi önemsiyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = AfterPresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Gelecekte hangi mesleği seçeceğime karar verdim.",
						IsCheckbox = true
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = AfterPresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Ders çalışma motivasyonu konusunda kendimi yeterli buluyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = AfterPresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kariyer gününde meslekler hakkında kafamdaki merak ettiğim soruların cevabını bulabileceğime inanıyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = AfterPresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Seçmeyi düşündüğüm meslekler hakkında fikir sahibiyim.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = AfterPresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kendimi başarılı bir öğrenci olarak görüyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = AfterPresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kariyer gününde dinleyeceğim meslek tanıtım sunumunu elle seçim yerine internet ortamında seçebiliyor olmamı olumlu buluyorum.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = AfterPresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "İnternet ortamındaki sunum seçim uygulamasını kolaylıkla kullanabildim.",
						IsCheckbox = true,
					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = AfterPresentationQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Bunların dışında varsa eklemek istediğiniz görüşlerinizi yazınız.",
						IsCheckbox = false,
					}
				};
				context.AddRange(Q);

				var BeierQuestionnarie = new Questionnarie()
				{
					QuestionnarieName = "Beier",
					IsSentiment = true
				};
				context.AddRange(BeierQuestionnarie);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Büyüdüğüm zaman",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Arkadaşlar",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Yaramazlık yaptığım zaman",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Okulda",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Okulda",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Bir türlü unutmadığım",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "İyi arkadaşlar",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Evimiz",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Annelerin en iyisi",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Geçen sene",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Elimden gelseydi",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
				  {
						QuestionName="Benim en iyi",
						IsCheckbox=false,
	
				  }
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Öğretmenler",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Annemi severim ama",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Canım sıkılınca",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Pişman olduğum",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Ailem",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Bana göre okul",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Arkadaş olarak hoşlandığım kimseler",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Bazen babam",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Eskiden",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Başkalarına göre",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Keşke annem",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "İşlerin başında ben olsaydım",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "En büyük üzüntüm",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Tahsilimi bitirsem",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Babaların iyisi",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Yapmamam gereken",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kardeşlerim",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "En çok istediğim",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Beceremediğim şey",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Hayatın en kötü tarafı",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Eğer annem",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Cezalar ve yasaklar",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kurtulmak istediğim üzüntü",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kötü bir baba",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Yaptığım en kötü şey",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "İyi öğretmenlerin yapması gereken",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Evde her şey",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Hatırımda kalan",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Beni en çok endişelendiren şey",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Dileğim",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Annem",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Çocuklar",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Eğer babam",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Korktuğum şey",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Ben küçükken",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Büyükler",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Vazgeçebilsem",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Ders kitaplarını kapatınca",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Vücudum",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Babam ve ben",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);

				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Kendi evim olunca",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Yalnız kalınca",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				Q = new QuestionnarieQuestion()
				{
					Questionnarie = BeierQuestionnarie,
					Question = new Question()
					{
						QuestionName = "Hayatta olmak istediğim şey",
						IsCheckbox = false,

					}
				};
				context.AddRange(Q);
				
				context.SaveChanges();
			}

		}
	}
}
