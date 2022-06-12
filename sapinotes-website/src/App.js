import React, { useEffect } from "react";
import Header from "./Header";
import { useNavigate } from "react-router-dom";

function App() {
  const navigate = useNavigate();
  useEffect(() => {
    if (!localStorage.getItem("user-info")) {
      navigate("/login");
    }
  });

  return (
    <div>
      <Header />
      <div className="bodydiv-with-nav"></div>
    </div>
  );
}

export default App;
