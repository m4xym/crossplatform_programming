import React, { useState } from "react";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import NavigationBar from "../components/NavigationBar";

interface Lab2ComponentProps {}

const Lab2Component: React.FC<Lab2ComponentProps> = () => {
  const [textInput, setTextInput] = useState("");
  const [responseText, setResponseText] = useState("");

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
      const response = await axios.post("http://localhost:5045/lab2", {
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
        <h3>Lab 2</h3>
        <p>
          Багато хто, ймовірно, чув пісні про пригоди жабка Crazy Frog. Цього
          разу невгамовне миле створення вирішило підкріпитися, але навіть таку
          просту дію вирішило виконати у вигляді гри. Отже, у кожній клітині
          квадратного ігрового поля, розбитого на N×N (N ≤ 50) клітин,
          знаходиться один комар вагою aij (вага комара – натуральне число ≤
          50), i – номер рядка, j – номер стовпця. Жабеня, стрибаючи з клітини
          на клітину, їсть комарів. Правила гри такі - у кожному стовпці можна
          з'їсти трохи більше одного комара. Щоразу при з'їданні комара
          запам'ятовуємо номер рядка, звідки з'їдено комар, і сума номерів
          рядків, у яких з'їдено комарі, наприкінці гри має бути точно дорівнює
          N. Врахуйте, якщо з якогось рядка з'їдено кілька комарів, то номер
          даного рядка бере участь у підрахунку більше одного разу. Визначте
          максимальну вагу комарів, яку можна з'їсти при дотриманні наведених
          правил.
        </p>
        <p>
          Перший рядок вхідних даних містить число N. Наступні N рядків містять
          N чисел aij, розділених пробілами.
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

export default Lab2Component;
