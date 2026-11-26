import React, { useState } from "react";
import ListarReceitas from "./Componentes/ListarReceitas";
import CardReceita from "./Componentes/CardReceita";
import ListarIngredientes from "./Componentes/ListarIngredientes";
import FormIngrediente from "./Componentes/FormIngrediente";
import { Ingrediente } from "./Models/Ingrediente";
import "./app.css";

function App() {
  const [receitaSelecionada, setReceitaSelecionada] = useState<string | null>(null);
  const [ingredienteEditando, setIngredienteEditando] = useState<Ingrediente | null>(null);
  const [versao, setVersao] = useState(0);

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
          {/* Cadastrar / Editar Ingrediente */}
          <FormIngrediente
            ingrediente={ingredienteEditando}
            onSalvar={() => {
              setIngredienteEditando(null);
              setVersao(versao + 1);
            }}
            onCancelar={() => setIngredienteEditando(null)}
          />

          {/* Listar Ingredientes */}
          <ListarIngredientes
            key={versao}
            onEditar={(ingrediente) => setIngredienteEditando(ingrediente)}
          />
        </div>
      </main>
    </>
  );
}

export default App;