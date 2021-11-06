# EncantosSalao

Uma aplicação Web para agendamento de corte de cabelo, unhas, e etc. :calendar: :nail_care:

:dart:  Projeto Integrador feito com ASP.NET Core para a Univesp. (Outubro 2021) 

## :information_source: Como o WebSite funciona

- Visitantes: 
  - vê as categorias dos serviços de beleza;
  - vê os salões e seus serviços;
  - lê as postagens do blog.
- Usuários autenticados:
  - agende compromissos usando o selecionador de data interativo; 
  - pode cancelar compromissos; 
  - pode avaliar salões para os quais tenham confirmado compromissos anteriores.  
- Gerente de Salão (papel de usuário):
  - confirma / recusa as marcações dos usuários para um determinado salão; 
  - controla quais serviços estão disponíveis para reserva no salão.
- Administrador:
  - cria / exclui postagens de blog, categorias, salões e serviços; 
  - pode revisar o histórico de compromissos.

## :hammer_and_pick: Construído com

- ASP.NET Core 3.1
- Entity Framework (EF) Core 3.1
- Microsoft SQL Server Express
- ASP.NET Identity System
- MVC Areas with Multiple Layouts
- Razor Pages, Sections, Partial Views
- View Components
- Repository Pattern
- Auto Мapping
- Dependency Injection
- Status Code Pages Middleware
- Exception Handling Middleware
- Sorting, Filtering, and Paging with EF Core
- Data Validation, both Client-side and Server-side
- Data Validation in the Models and Input View Models
- Custom Validation Attributes
- Responsive Design
- CloudinaryDotNet
- Bootstrap
- jQuery

## :gear: Configuração da aplicação

### 1. Dados de amostra
Você pode testar o website usuando as contas pré configuradas abaixo:
  - Usuário: user@user.com / senha: 123456
  - Gerente de Salão: manager@manager.com / senha: 123456
  - Administrador: admin@admin.com / senha: 123456
 

## :framed_picture: Screenshot - Home Page

![BeautyBooking-HomePage](https://res.cloudinary.com/beauty-booking/image/upload/v1588865868/SCREENSHOTS/1-home_orn9ng.png)

## :framed_picture: Screenshot - Make An Appointment Page

![BeautyBooking-MakeAnAppointment](https://res.cloudinary.com/beauty-booking/image/upload/v1588865868/SCREENSHOTS/4-make-an-appointment_zclidt.png)

## License

Este projeto está licenciado sob a [MIT License](LICENSE).

## Agradecimentos

#### Estamos usnado [ASP.NET-MVC-Template](https://github.com/NikolayIT/ASP.NET-MVC-Template) desenvolvido por:
- [Nikolay Kostov](https://github.com/NikolayIT)
- [Vladislav Karamfilov](https://github.com/vladislav-karamfilov)
- [Stoyan Shopov](https://github.com/StoyanShopov)
