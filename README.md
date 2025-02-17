# Генератор UI форм для WPF

Программа создает пользовательские интерфейсы на основе JSON шаблонов, делает скриншоты и разметку элементов для
использования в датасетах машинного обучения.

## Основные возможности

- Генерация UI форм по JSON шаблонам
- Автоматическое создание скриншотов
- Генерация файлов с координатами элементов
- Поддержка различных типов UI элементов:
    - Контейнеры (окна, формы, группы)
    - Элементы управления (кнопки, поля ввода, списки)
    - Композитные элементы (метки с полями ввода)

## Архитектура программы

Программа состоит из следующих основных компонентов:

1. **Модель данных**
    - `PageObject` - базовый класс для всех UI элементов
    - `ContainerPageObject` - абстрактный класс для контейнеров
    - Конкретные реализации элементов (ButtonPO, LabelPO и т.д.)

2. **Менеджер данных**
    - `DataManager` - синглтон для управления данными
    - Методы для добавления новых элементов и генерации случайных данных

3. **Основное окно**
    - `MainWindow` - главное окно приложения
    - Логика отображения и взаимодействия с UI

4. **Модели данных**
    - `PageObjectModel` - модель данных для элементов
    - `PageObjectDescription` - описание элементов

## Как использовать

1. Сгенерируйте JSON файлы с описанием UI с помощью программы tree_gui_generator:
   ```bash
   treegen.py 1000 --otp ./Json/trees/
   ```
   Это создаст 1000 JSON файлов с описаниями UI форм в папке Json/trees.

2. Поместите сгенерированные JSON файлы в папку `WpfApp1/Json/trees/` вашего проекта.

3. Запустите программу:
   ```bash
   WpfApp1.exe
   ```

4. Программа автоматически для каждого JSON файла:
    - Создаст UI форму с помощью WPF
    - Сделает скриншот формы
    - Сгенерирует файл с координатами элементов
    - Сохранит результаты в папке Photos:
        - PNG файл со скриншотом (например, photo902.png)
        - TXT файл с координатами элементов (например, photo902.txt)

## Формат выходных данных

Для каждого UI создаются:

1. PNG файл со скриншотом (в папке Photos)
2. TXT файл с координатами элементов (в папке Photos)

Пример файла с координатами:

```
0 0.5 0.5 0.993949368314052 0.982804869660912
17 0.5 0.993121947864365 0.997579747325621 0.0103170782034528
22 0.0284964583635865 0.0756241832313089 0.0545726640527938 0.0411995322924548
```

Формат каждой строки:

```
<тип_элемента> <центр_x> <центр_y> <ширина> <высота>
```

Где:

- `<тип_элемента>` - числовой идентификатор типа UI элемента (например, 0 - Window, 17 - Label и т.д.)
- `<центр_x>` - X-координата центра элемента (нормализованная от 0 до 1)
- `<центр_y>` - Y-координата центра элемента (нормализованная от 0 до 1)
- `<ширина>` - ширина элемента (нормализованная от 0 до 1)
- `<высота>` - высота элемента (нормализованная от 0 до 1)

Все координаты и размеры нормализованы относительно размеров окна, где:

- (0,0) - верхний левый угол окна
- (1,1) - нижний правый угол окна

## Требования

- .NET Framework 4.7.2 или выше
- Windows 10/11
- Минимум 2 ГБ оперативной памяти
