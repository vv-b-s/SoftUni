<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Product;
use AppBundle\Form\ProductType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use function Sodium\compare;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\RedirectResponse;
use Symfony\Component\HttpFoundation\Request;

class ProductController extends Controller
{
    /**
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index()
    {
        $products = $this->getDoctrine()->getRepository(Product::class)->findAll();



        usort($products, function (Product $p1,Product $p2){return $p1->getPriority()>$p2->getPriority();});

        return $this->render("product/index.html.twig",['products'=>$products]);
	}

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response|RedirectResponse
     */
    public function create(Request $request)
    {
        $product = new Product();

        $form = $this->createForm(ProductType::class, $product);

        $form->handleRequest($request);
        if($form->isSubmitted()&&$form->isValid())
        {
            $em = $this->getDoctrine()->getManager();
            $em->persist($product);
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render('product/create.html.twig',[
                'form'=>$form->createView(),
                'product'=>$product
            ]);
	}

    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response|RedirectResponse
     */
    public function edit($id, Request $request)
    {
        $product = $this->getDoctrine()->getRepository(Product::class)->find($id);

        $form = $this->createForm(ProductType::class, $product);
        $form->handleRequest($request);

        if($form->isSubmitted()&&$form->isValid())
        {
            $em = $this->getDoctrine()->getManager();
            $em->merge($product);
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render(':product:edit.html.twig',[
            'form'=>$form->createView(),
            'product'=>$product
        ]);
    }
}
