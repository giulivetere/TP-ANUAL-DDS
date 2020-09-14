///////////////////////////////////////////////////////////
//  Criterio.cs
//  Implementation of the Class Criterio
//  Generated by Enterprise Architect
//  Created on:      12-Sep-2020 7:23:02 PM
//  Original author: Franco
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



/// <summary>
/// This class declares an interface common to all supported algorithms. Context
/// uses this interface to call the algorithm defined by a ConcreteStrategy.
/// </summary>
public abstract class Criterio {

	public Criterio(){

	}

	~Criterio(){

	}

	public abstract void vincular();

}//end Criterio