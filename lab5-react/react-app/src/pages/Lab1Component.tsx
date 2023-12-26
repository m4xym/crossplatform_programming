import React, { useState } from "react";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import NavigationBar from "../components/NavigationBar";

interface Lab1ComponentProps {}

const Lab1Component: React.FC<Lab1ComponentProps> = () => {
  const [textInput, setTextInput] = useState("");
  const [responseText, setResponseText] = useState("");

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
      console.log("Request Body:", { text: textInput });
      const response = await axios.post("http://localhost:5045/lab1", {
        text: textInput,
      });
      console.log("Response Data:", response.data);
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
        <h3>Lab 1</h3>
        <p>
          Перестановка N елементів - це впорядкований набір n різних чисел від 1
          до N. Кількість всіх перестановок порядку N дорівнює PN = N! Необхідно
          знайти перестановку за її номером в лексикографічному порядку (за
          алфавітом). Наприклад, для N=3 лексикографічний порядок перестановок
          виглядає наступним чином: (1,2,3), (1,3,2), (2,1,3), (2,3,1), (3,1,2),
          (3,2,1). Таким чином, перестановка (2,3,1) має в даній послідовності
          число 4.
        </p>
        <p>
          У першому рядку вхідних даних записується число N (1 ≤ N ≤ 12) -
          кількість елементів в перестановці, у другому - число K (1 ≤ K ≤ N!) -
          число перестановки.
        </p>
        <p>Вихідні дані - N чисел - потрібна перестановка, через пробіл.</p>
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

export default Lab1Component;
