import { useEffect, useState } from "react";
import { DetalhesReceita } from "../Models/DetalhesReceita";
import axios from "axios";
import"./Css/CardReceita.css";

function CardReceita({id, onVoltar}: {
    id: string;
    onVoltar: () => void;
}) {
    const [detalhes, setDetalhes] = useState<DetalhesReceita | null>(null);
    const [carregando, setCarregando] = useState(true);

    useEffect(() =>{
        axios.get<DetalhesReceita>(`http://localhost:5093/api/receitas/${id}`)
        .then((resposta) => {
        setDetalhes(resposta.data);
        })
        .catch((erro) => {
            console.error("Erro ao buscar detalhes da receita: ", erro);
        })
        .finally(() => {
            setCarregando(false);
        });
    }, [id]);

    if (carregando){
        return <p>Carregando detalhes da receita...</p>;
    }

    if (!detalhes) {
        return <p>Não foi possível carregar a receita.</p>;
    }

    return (
        <div className="detalhes-receita">
            <div className="detalhes-1">
                <button className="botao-voltar" onClick={onVoltar}>
                    ←
                </button>
                <h2 className="titulo-detalhes">{detalhes.nome}</h2>
                <p className="descricao-detalhes">{detalhes.descricao}</p>

                <div className="titulo-secao-container">
                    <h3 className="titulo-secao">Ingredientes</h3>
                </div>

                <ul className="lista-ingredientes">
                    {detalhes.ingredientes.map((ingrediente, index) => (
                        <li key={index}>
                            {ingrediente.quantidade && ingrediente.unidadeMedida
                                ?`${ingrediente.quantidade} ${ingrediente.unidadeMedida} de 
                                ${ingrediente.nome}`
                                : ingrediente.quantidade
                                
                                ? `${ingrediente.quantidade} ${ingrediente.nome}`
                                : ingrediente.nome
                            }
                        </li>
                    ))}
                </ul>
                
                <div className="titulo-secao-container">
                    <h3 className="titulo-secao">Modo de Preparo</h3>                
                </div>
                <ol className="lista-etapas">
                    {detalhes.etapas.map((etapa) => (
                        <li key={etapa.ordem}>
                            {etapa.descricao}
                        </li>
                    ))}
                </ol>
            </div>
            
            <div className="separador-detalhes"></div>

            <div className="detalhes-2">
                <img
                    src="/imagem-receita.jpg"
                    alt="Imagem ilustrativa de culinária"
                    className="imagem-receita"
                />
            </div>

        </div>
    );
}

export default CardReceita;
