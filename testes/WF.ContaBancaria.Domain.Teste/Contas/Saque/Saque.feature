Funcionalidade: Saque em Conta Corrente
				Operações de saque em conta corrente de um cliente

@TesteAceitacaoContaCorrente

Cenario: Saque Realizado com Sucesso
	Dado Uma Conta Corrente Ativa
	Quando For efetuado um saque
	E O valor do saque e superior a zero
	Então Receberei uma mensagem de saque realizado com sucesso 	


Cenario: Saque com valor negativo 
	Dado Uma Conta Corrente Ativa
	Quando For efetuado um saque
	E O valor é negativo
	Então Receberei uma mensagem de Valor deve ser positivo	

Cenario: Saque com valor 0 
	Dado Uma Conta Corrente Ativa
	Quando For efetuado um saque
	E O valor é zero
	Então Receberei uma mensagem de Valor não pode ser igual a zero