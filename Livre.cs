using System;

public class Livre
{
	private string titre { get; set; }
	private string Auteur { get; set; }
	private int static inc;
	private int id { get; set; }
	public Livre(string Auteur, string titre)
	{
		this.Auteur = Auteur;
		this.titre = titre;
		this.id = inc++;
	}
}
