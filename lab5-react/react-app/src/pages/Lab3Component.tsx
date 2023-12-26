import React, { useState } from "react";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import NavigationBar from "../components/NavigationBar";

interface Lab3ComponentProps {}

const Lab3Component: React.FC<Lab3ComponentProps> = () => {
  const [textInput, setTextInput] = useState("");
  const [responseText, setResponseText] = useState("");

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
      const response = await axios.post("http://localhost:5045/lab3", {
        text: textInput,
      });
      setResponseText(response.data);
    } catch (error) {
      console.error(error);
      setResponseText("Error: Failed to send data to the server.");
    }
  };

  return (
    <div>
      <NavigationBar />
      <div className="container mt-5 bg-light">
        <h3>Lab 3</h3>
        <p>
          Ви є одним із розробників нової комп'ютерної гри. Гра відбувається на
          прямокутній дошці, що складається з W×H клітин. Кожна клітина може або
          містити або не містити фішку. Важливою частиною гри є перевірка того,
          чи з'єднані дві фішки шляхом, що задовольняє наступні властивості:
          Шлях повинен складатися з відрізків вертикальних та горизонтальних
          прямих. Шлях не повинен перетинати інші фішки. При цьому частина шляху
          може опинитися поза дошкою. Наприклад: Фішки з координатами (1,3) та
          (4,4) можуть бути з'єднані. Фішки з координатами (2,3) та (5,3) теж
          можуть бути з'єднані. А ось фішки з координатами (2,3) і (3,4)
          з'єднати не можна - будь-який шлях, що їх з'єднує, перетинає інші
          фішки. Вам необхідно написати програму, яка перевіряє, чи можна
          з'єднати дві фішки шляхом, що має вищевказані властивості, і, у разі
          позитивної відповіді, визначальну мінімальну довжину такого шляху
          (вважається, що шлях має злами, початок і кінець тільки в центрах
          клітин (або «уявних клітин») », розташованих поза дошкою), а відрізок,
          що з'єднує центри двох сусідніх клітин, має довжину 1).
        </p>
        <p>
          Вхідні дані: Перший рядок містить два натуральні числа: W – ширина
          дошки, H – висота дошки (1≤W,H≤75). Наступні H рядків містять опис
          дошки: кожен рядок складається з W символів: символ «X» позначає
          фішку, символ «.» позначає порожнє місце. Всі інші рядки містять опис
          запитів: кожен запит складається з чотирьох натуральних чисел,
          розділених пробілами – X1, Y1, X2, Y2, причому 1≤X1,X2≤W, 1≤Y1,Y2≤H.
          Тут (X1, Y1) та (X2, Y2) – координати фішок, які потрібно з'єднати
          (ліва верхня клітина має координати (1,1)). Гарантується, що ці
          координати не збігатимуться (крім останнього запиту; див. далі).
          Останній рядок містить запит, що складається із чотирьох чисел 0; цей
          запит обробляти не треба. Кількість запитів вбирається у 20.
        </p>
        <p>
          Вихідні дані: Для кожного запиту у вихідний файл OUTPUT.TXT необхідно
          вивести одне ціле число на окремому рядку – довжину найкоротшого шляху
          або 0, якщо такого шляху не існує.
        </p>
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <textarea
              value={textInput}
              onChange={(e) => setTextInput(e.target.value)}
              className="form-control"
              rows={10}
              placeholder="Enter your text here..."
            />
          </div>
          <button type="submit" className="btn btn-primary mt-2">
            Submit
          </button>
        </form>
        <p className="mt-3">{responseText}</p>
      </div>
    </div>
  );
};

export default Lab3Component;
