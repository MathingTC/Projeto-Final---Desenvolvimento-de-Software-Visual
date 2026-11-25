import { useEffect, useState } from "react";
import { DetalhesReceita } from "../Models/DetalhesReceita";
import axios from "axios";

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
        <div>
            <button onClick={onVoltar}>
                Voltar
            </button>
            <h2>{detalhes.nome}</h2>
            <p>{detalhes.descricao}</p>
            <h3>Ingredientes</h3>

            <ul>
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

            <h3>Modo de Preparo</h3>
            <ol>
                {detalhes.etapas.map((etapa) => (
                    <li key={etapa.ordem}>
                        {etapa.descricao}
                    </li>
                ))}
            </ol>
        </div>
    );
}

export default CardReceita;
