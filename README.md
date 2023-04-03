Простой прототип игры реализованный на основе стандартного для unity EC подхода.

Игра была разделена на несколько сцен, соответствующих основным этапам игры (выбор корабля и бой), слабо связанных друг с другом для удобства разработки логики каждой из сцен по отдельности. Одна сцена является стартовой для игры, в ней происходит инициализация начальных конфигов, а также управление верхнеуровневым состоянием игры. Основные конфиги были вынесены в отдельные __Scriptable object__ ы.

Для управления базовой логикой игры было создано несколько __менеджеров-синглтонов__, так как использование dependency injection в данном случае излишне. Для взаимодействия с ui был написан небольшой __фреймворк для управления экранами__ и их элементами. Для управления врагом был написан урезанный вариант паттерна __behavior tree__.

Код был написан таким образом, чтобы его можно было без проблем расширить при необходимости, но в то же время не переусложнять его выделением абстракций, без которых на данном этапе можно обойтись.
