import React from "react";
import ListarReceitas from "./Componentes/ListarReceitas";

function App() {
  return (
    <>
      {/* Header */}
    
      <main>
        <div className="coluna-receitas">
          {/* listarReceitas */}
          <ListarReceitas />
        </div>

        <div className="coluna-ingredientes">
          {/* Listar Ingredientes */}
        </div>

      </main>
    </>
  );
}

export default App;