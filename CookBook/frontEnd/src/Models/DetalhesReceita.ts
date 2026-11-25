export interface DetalhesReceita {
    nome: string;
    descricao: string;
    ingredientes: {
        nome: string;
        quantidade: number | null;
        unidadeMedida: string | null;
    }[];
    etapas: {
        ordem: number;
        descricao: string;
    }[];
}