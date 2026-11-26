import React, { useState } from "react";
import ListarReceitas from "./Componentes/ListarReceitas";
import CardReceita from "./Componentes/CardReceita";
import "./app.css";

function App() {
  const [receitaSelecionada, setReceitaSelecionada] = useState<string | null>(null);
  if (receitaSelecionada !== null){
    return (
      <CardReceita
        id={receitaSelecionada}
        onVoltar={() => setReceitaSelecionada(null)}
      />
    );
  }

  return (
    <>
      <div>
        {/* Header */}
      </div>
    
      <main>
        <div className="coluna-receitas">
          {/* listarReceitas */}
          <ListarReceitas onSelecionarReceita={(id) => setReceitaSelecionada(id)} />
        </div>

        <div className="coluna-ingredientes">
          {/* Listar Ingredientes */}
        </div>
      </main>
    </>
  );
}

export default App;