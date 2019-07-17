Funcionalidade: Operações em Conta Corrente
				Operações de deposito e saque em conta corrente de um cliente

@TesteContaCorrente

Cenario: Saque acima do limite diario
	Dado Uma Conta Corrente Ativa com limite diario de 500
	Quando Sacar um valor de 300
	E Sacar um valor de 400
	Então Receberei uma mensagem de Limite diario para saque excedido 	


Cenario: Conta sem saldo para saque
	Dado Uma Conta Corrente Ativa com limite diario de 500 e saldo de 400 
	Quando Sacar um valor de 500	
	Então Receberei uma mensagem de Saldo para saque indisponivel