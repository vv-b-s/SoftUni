package shoppinglist.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import shoppinglist.bindingModel.ProductBindingModel;
import shoppinglist.entity.Product;
import shoppinglist.repository.ProductRepository;

import javax.validation.Valid;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

@Controller
public class ProductController {

	private final ProductRepository productRepository;

	@Autowired
	public ProductController(ProductRepository productRepository) {
		this.productRepository = productRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Product> products = productRepository.findAll();
		products = products.stream().sorted(Comparator.comparing(Product::getPriority)).collect(Collectors.toList());

		model.addAttribute("products", products);
		model.addAttribute("view", "product/index");
		return "base-layout";
	}


	@GetMapping("/create")
	public String create(Model model) {
		model.addAttribute("view","product/create");
		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, @Valid ProductBindingModel productBindingModel, BindingResult bindingResult) {
		if(bindingResult.hasErrors())
			return "redirect:/create";

		Product product = new Product(productBindingModel.getPriority(),productBindingModel.getName(), productBindingModel.getQuantity(), productBindingModel.getStatus());
		productRepository.saveAndFlush(product);

		return "redirect:/";

	}


	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {
		Product product = productRepository.findOne(id);
		if(product==null)
			return "redirect:/";

		model.addAttribute(product);
		model.addAttribute("view", "product/edit");

		return "base-layout";
	}

	@PostMapping("/edit/{id}")
	public String editProcess(Model model, @PathVariable int id, @Valid ProductBindingModel productBindingModel, BindingResult bindingResult) {
		if(bindingResult.hasErrors())
			return String.format("redirect:/edit/%d",id);
		Product product = productRepository.findOne(id);

		product.setPriority(productBindingModel.getPriority());
		product.setName(productBindingModel.getName());
		product.setQuantity(productBindingModel.getQuantity());
		product.setStatus(productBindingModel.getStatus());

		productRepository.saveAndFlush(product);

		return "redirect:/";
	}
}
