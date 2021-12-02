import React, {Component} from 'react';
import {
  FlatList,
  StyleSheet,
  Text,
  View,
  ScrollView,
  Image,
  TextInput,
  Button,
} from 'react-native';
import base64 from 'react-native-base64';

import api from '../services/api';
import {TouchableOpacity} from 'react-native-gesture-handler';

import { Picker } from "@react-native-picker/picker";
import AsyncStorage from '@react-native-async-storage/async-storage';

const InputMultiple = (props) => {
  return (
      <TextInput
          {...props} // Inherit any props passed to it; e.g., multiline, numberOfLines below
          editable
      />
  );
}

export default class Cadastro extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaProjetos: [],
      idTema: 0,
      nomeProjeto: '',
      descricao: ''
    };
  }

  Inscrever = async idProjeto => {
    try {
      const token = await AsyncStorage.getItem('userToken');
      var decodeToken = base64.decode(token.split(".")[1]);
      var decodeToken = decodeToken.split('"')[7].toString();
      console.warn(decodeToken)


      const response = await api.post('/projetos',
        {
            idTema: this.state.idTema,
            nomeProjeto: this.state.nomeProjeto,
            descricao: this.state.descricao,
            idProfessor: decodeToken,
        },
        {
            headers: {
                Authorization: 'Bearer ' + token,
            }
        });

      if (response.status == 201) {
          console.warn("Projeto cadastrado")
          this.setState({
              idTema: 0,
              nomeProjeto: '',
              descricao: '',
              
          })
      }
    } catch (error) {
        console.warn(error);
    }
  };

  // define a função que faz a chamada para a API e traz os eventos
  buscarProjetos = async () => {
    // define uma constante pra receber a resposta da requisição
    const resposta = await api.get('/Projetos');
    // com a função console.warn() é possível mostrar alertas na tela do dispositivo mobile
    // console.warn(resposta.data[0])
    // recebe o corpo da resposta
    const dadosDaApi = resposta.data;
    // atualiza o state listaEventos com este corpo da requisição
    this.setState({listaProjetos: dadosDaApi});
  };

  render() {
    return (
      <View style={styles.backgroundpage}>
                <ScrollView style={styles.ScrollView} >
                    <View style={styles.header}>
                        <View style={styles.pageTitle}>
                            <Text style={styles.title}>Cadastro</Text>
                        </View>
                    </View>
                    <View style={styles.main}>
                        <Picker
                            selectedValue={this.state.idTema}
                            onValueChange={(itemValue, itemIndex) => this.setState({ idTema: itemValue })}
                            style={styles.picker}>
                            <Picker.Item label="Selecione o tema" value="0" />
                            <Picker.Item label="HQ" value="1" />
                            <Picker.Item label="Gestão" value="2" />
                        </Picker>
                        <TextInput
                            style={styles.input}
                            onChangeText={nomeProjeto => this.setState({ nomeProjeto })}
                            value={this.state.nomeProjeto}
                            placeholder="Titulo do projeto"
                            keyboardType="default"
                        />
                        <InputMultiple
                            multiline
                            numberOfLines={4}
                            onChangeText={descricao => this.setState({ descricao })}
                            value={this.state.descricao}
                            style={styles.multipleInput}
                            placeholder="Descrição do projeto"
                        />

                        <TouchableOpacity
                            title="Cadastro"
                            style={styles.btn}
                            onPress={() => this.Inscrever()}
                        >
                            <Text style={styles.btnText}>Cadastrar</Text>
                        </TouchableOpacity>
                    </View>
                </ScrollView>
            </View>
    );
  }
}

const styles = StyleSheet.create({
  backgroundpage: {
      flex: 1,
      backgroundColor: '',
      alignItems: 'center'
  },
  ScrollView: {
      width: '100%'
  },

  header: {
      alignItems: 'center'
  },


  pageTitle: {
      width: '45%',
      borderBottomColor: "#477ed6",
      borderBottomWidth: 1,
      alignItems: 'center'
  },

  title: {
      textTransform: 'uppercase',
      color: '#477ed6',
      fontWeight: 'bold',
      fontSize: 26,
      letterSpacing: 5,
      marginTop: 40,
  },

  main: {
      flex: 2,
      marginTop: 40,
      width: '100%',
      alignItems: 'center'
  },

  picker: {
      width: '78%',
      borderRadius: 60,
      borderColor: "#009DF5",
      placeholderTextColor: '#A4A4A4',
      borderStyle: 'solid',
      borderWidth: 1,
      backgroundColor: '#FFF',
      placeholderTextColor: '#A4A4A4',
  },

  input: {
      width: '80%',
      borderRadius: 20,
      borderColor: "#477ed6",
      borderStyle: 'solid',
      borderWidth: 1,
      backgroundColor: '#FFF',
      textAlign: 'center',
      marginTop: 10,
  },

  multipleInput: {
      width: '80%',
      borderRadius: 20,
      borderColor: "#477ed6",
      borderStyle: 'solid',
      borderWidth: 1,
      backgroundColor: '#FFF',
      textAlign: 'center',
      marginTop: 20,
  },
  btn: {
      width: '30%',
      borderColor: '#477ed6',
      borderWidth: 1,
      backgroundColor: '#FFF',
      borderRadius: 10,
      marginTop: 20,
      height: 50,
      alignItems: 'center',
      justifyContent: 'center',
      padding: 10,
      
  },

  btnText: {
      color: '#477ed6',
      fontWeight: 'bold',
      fontSize: 18
  }
});
