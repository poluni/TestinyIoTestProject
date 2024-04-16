# TestinyIo TestProject

Application Under Test: https://app.testiny.io/

Repo: https://github.com/poluni/TestinyIoTestProject

API Documentation: https://www.testiny.io/docs/api-quickstart/

Development platform: .Net Framework v8

Фрэймворк: собственной разработки на основе на основе Selenium WebDriver + NUnit + RestSharp

Паттерны автоматизации: PageObject + Value Of Object

Reporting: Allure TestOps

Logging: NLog

Source Control System: GIT

CI/CD: GitHub Actions.

GITstrategy:
**master** — main branch

**develop** — the main development branch. Each commit to the develop branch is a result of a feature development completion. Each commit should be a result of a merge of merge request from a feature branch.

**feature** — each new feature should reside in its own branch, which is created off of the latest develop version. When a feature is complete, it gets merged back into develop via merge request. After the feature branch is deleted.

Что автоматизируем: Smoke + Regression планы прогона

+ Уровень GUI
  a) 6 позитивных тестов

    i. 	1 тест на проверку поля для ввода на граничные значения

    ii. 	1 тест на проверку всплывающего сообщения

    iii. 	1 тест на создание сущности

    iv. 	1 тест на удаление сущности

    v. 	1 тест отображения диалогового окна

    vi. 	1 тест на загрузку файла

  b) 3 негативных теста

    i. 	1 тест на использование некорректных данных (попытка загрузитьнедопустимый формат)

    ii. 	1 тест на ввод данных превышающих допустимые

    iii. 	1 тест воспроизводящий любой дефект

+ Уровень API

  a) Get - 3 теста - NFE + 2 AFE

  b) Post
